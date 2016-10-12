using FrontEnd.Agents;
using FrontEnd.Agents.Models;
using FrontEnd.Exceptions;
using FrontEnd.Viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class CursusController : Controller
    {
        private ICursusService _agent;

        public CursusController(ICursusService agent)
        {
            _agent = agent;
            agent.BaseUri = new Uri(@"http://localhost:3784/");
        }

        public ActionResult Index()
        {
            var weekNo = GetWeeknumberFrom(DateTime.Today);
            var yearNo = DateTime.Today.Year;

            return RedirectToAction("IndexPerWeek", new { weeknummer = weekNo, jaar = yearNo });
        }
        
        public ActionResult IndexPerWeek(int weeknummer, int jaar)
        {
            var list = _agent.ApiV1CursusGet();
            list = list.Where(cursus =>
            {
                DateTime time = parseTime(cursus.Startdatum);
                return GetWeeknumberFrom(time) == weeknummer && time.Year == jaar;
            }).OrderBy(cursus => parseTime(cursus.Startdatum)).ToList();

            var model = new IndexViewModel { Cursussen = list, Weeknummer = weeknummer, Year = jaar };
            return View(model);
        }

        [HttpGet]
        public ActionResult Import()
        {
            return View(new ImportViewModel());
        }

        [HttpPost]
        public ActionResult Import(IFormFile data)
        {
            var importmodel = new ImportViewModel();
            List<CursusInstantie> cursussen = new List<CursusInstantie>();
            using (var stream = new StreamReader(data.OpenReadStream()))
            {
                int linenumber = 0;
                while (!stream.EndOfStream)
                {
                    string titel = stream.ReadLine();
                    linenumber++;
                   
                    if (Regex.IsMatch(titel, @"^Titel: .+$"))
                    {
                        importmodel.validationError = new IllegalFormatException { ErrorCode = "IF001", ErrorMessage = $"Regel {linenumber} begint niet met Titel" };
                        return View(importmodel);
                    }
                    titel = titel.Substring(titel.IndexOf(':') + 1).Trim();

                    string cursuscode = stream.ReadLine();
                    linenumber++;
                    if (!cursuscode.StartsWith("Cursuscode: "))
                    {
                        importmodel.validationError = new IllegalFormatException { ErrorCode = "IF002", ErrorMessage = $"Regel {linenumber} begint niet met Cursuscode" };
                        return View(importmodel);
                    }
                    cursuscode = cursuscode.Substring(cursuscode.IndexOf(':') + 1).Trim();

                    string duur = stream.ReadLine();
                    linenumber++;
                    if (!duur.StartsWith("Duur: "))
                    {
                        importmodel.validationError = new IllegalFormatException { ErrorCode = "IF003", ErrorMessage = $"Regel {linenumber} begint niet met Duur" };
                        return View(importmodel);
                    }
                    duur = duur.Substring(duur.IndexOf(':') + 1).Trim();

                    string datum = stream.ReadLine();
                    linenumber++;
                    if (!datum.StartsWith("Startdatum: "))
                    {
                        importmodel.validationError = new IllegalFormatException { ErrorCode = "IF004", ErrorMessage = $"Regel {linenumber} begint niet met Startdatum" };
                        return View(importmodel);
                    }
                    datum = datum.Substring(datum.IndexOf(':') + 1).Trim();

                    string empty = stream.ReadLine();
                    linenumber++;
                    if (!String.IsNullOrWhiteSpace(empty))
                    {
                        importmodel.validationError = new IllegalFormatException { ErrorCode = "IF005", ErrorMessage = $"Regel {linenumber} begint bevat geen lege regel" };
                        return View(importmodel);
                    }
                    int duurAsNumber = Int32.Parse("" + duur[0]);
                    Cursus cursus = new Cursus { Code = cursuscode, Duur = duurAsNumber, Titel = titel };
                    try
                    {
                        cursus.Validate();
                    }
                    catch (ValidationException e)
                    {
                        importmodel.validationError = new IllegalFormatException { ErrorCode = "IF006", ErrorMessage = $"{e.Message}" };
                        return View(importmodel);
                    }
                    CursusInstantie instantie = new CursusInstantie { Cursus = cursus, Startdatum = datum };
                    try
                    {
                        instantie.Validate();
                    }
                    catch (ValidationException e)
                    {
                        importmodel.validationError = new IllegalFormatException { ErrorCode = "IF006", ErrorMessage = $"{e.Message}" };
                        return View(importmodel);
                    }
                    cursussen.Add(instantie);
                }
            }
            var result = _agent.ApiV1CursusPost(cursussen);

            if (result is PostFailure)
            {
                importmodel.failure = (result as PostFailure);
            }
            else
            {
                importmodel.success = (result as PostSuccess);
            }
            return View(importmodel);
        }

        private DateTime parseTime(string time)
        {
            return DateTime.ParseExact(time, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private int GetWeeknumberFrom(DateTime time)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            return currentCulture.Calendar.GetWeekOfYear(
                        DateTime.Today,
                        currentCulture.DateTimeFormat.CalendarWeekRule,
                        currentCulture.DateTimeFormat.FirstDayOfWeek
                );
        }
    }
}