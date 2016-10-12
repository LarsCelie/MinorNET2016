using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Agents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Controllers;
using FrontEnd.Agents.Models;
using Microsoft.Rest;

namespace FrontEnd.Controllers
{
    public class CursusController : Controller
    {
        private CursusService _agent;

        public CursusController(CursusService agent)
        {
            _agent = agent;
            agent.BaseUri = new Uri(@"http://localhost:3784/");
        }

        public ActionResult Index()
        {
            var model = _agent.ApiV1CursusGet();
            return View(model);
        }

        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import(IFormFile data)
        {
            using (var stream = new StreamReader(data.OpenReadStream()))
            {
                int linenumber = 0;
                List<CursusInstantie> cursussen = new List<CursusInstantie>();
                while (!stream.EndOfStream)
                {
                    string titel = stream.ReadLine();
                    linenumber++;
                    if (!titel.StartsWith("Titel: "))
                    {
                        throw new IllegalFormatException { ErrorCode = "IF001", ErrorName = $"Regel {linenumber} begint niet met Titel" };
                    }
                    titel = titel.Substring(titel.IndexOf(':') + 1).Trim();

                    string cursuscode = stream.ReadLine();
                    linenumber++;
                    if (!cursuscode.StartsWith("Cursuscode: "))
                    {
                        throw new IllegalFormatException { ErrorCode = "IF002", ErrorName = $"Regel {linenumber} begint niet met Cursuscode" };
                    }
                    cursuscode = cursuscode.Substring(cursuscode.IndexOf(':') + 1).Trim();

                    string duur = stream.ReadLine();
                    linenumber++;
                    if (!duur.StartsWith("Duur: "))
                    {
                        throw new IllegalFormatException { ErrorCode = "IF003", ErrorName = $"Regel {linenumber} begint niet met Duur" };
                    }
                    duur = duur.Substring(duur.IndexOf(':') + 1).Trim();

                    string datum = stream.ReadLine();
                    linenumber++;
                    if (!datum.StartsWith("Startdatum: "))
                    {
                        throw new IllegalFormatException { ErrorCode = "IF004", ErrorName = $"Regel {linenumber} begint niet met Startdatum" };
                    }
                    datum = datum.Substring(datum.IndexOf(':') + 1).Trim();

                    string empty = stream.ReadLine();
                    linenumber++;
                    if (!String.IsNullOrWhiteSpace(empty))
                    {
                        throw new IllegalFormatException { ErrorCode = "IF005", ErrorName = $"Regel {linenumber} begint bevat geen lege regel" };
                    }
                    int duurAsNumber = Int32.Parse("" + duur[0]);
                    Cursus cursus = new Cursus { Code = cursuscode, Duur = duurAsNumber, Titel = titel };
                    try
                    {
                        cursus.Validate();
                    } catch (ValidationException e)
                    {
                        throw new IllegalFormatException { ErrorCode = "IF006", ErrorName = $"{e.Message}" };
                    }

                    CursusInstantie instantie = new CursusInstantie { Cursus = cursus, Startdatum = datum };
                    try
                    {
                        instantie.Validate();
                    }
                    catch (ValidationException e)
                    {
                        throw new IllegalFormatException { ErrorCode = "IF006", ErrorName = $"{e.Message}" };
                    }
                    cursussen.Add(instantie);
                }

                _agent.ApiV1CursusPost(cursussen);
            }
            return View();
        }
    }
}