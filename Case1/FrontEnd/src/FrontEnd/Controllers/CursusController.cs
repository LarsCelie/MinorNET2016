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
            if (weeknummer < 1)
            {
                weeknummer = 52;
                jaar--;
            } else if (weeknummer > 52)
            {
                weeknummer = 1;
                jaar++;
            }

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
        public ActionResult Import(IFormFile data, DateTime? startdatum, DateTime? einddatum)
        {
            var importmodel = new ImportViewModel();
            List<CursusInstantie> cursussen = new List<CursusInstantie>();
            try
            {

                using (var stream = new StreamReader(data.OpenReadStream()))
                {
                    int linenumber = 0;
                    while (!stream.EndOfStream)
                    {
                        string titel = ValidateFormat(stream.ReadLine(), @"^Titel: .+$", ref linenumber);

                        string cursuscode = ValidateFormat(stream.ReadLine(), @"^Cursuscode: [A-Z0-9]{1,10}$", ref linenumber);

                        string duur = ValidateFormat(stream.ReadLine(), @"^Duur: [1-5] dagen$", ref linenumber);

                        string datum = ValidateFormat(stream.ReadLine(), @"Startdatum: \d{1,2}/\d{1,2}/\d{4}", ref linenumber);

                        //Empty line
                        ValidateFormat(stream.ReadLine(), @"^\s*$", ref linenumber);

                        int duurAsNumber = Int32.Parse("" + duur[0]);
                        Cursus cursus = new Cursus { Code = cursuscode, Duur = duurAsNumber, Titel = titel };
                        try
                        {
                            cursus.Validate();
                        }
                        catch (ValidationException e)
                        {
                            throw new IllegalFormatException { ErrorCode = "IF002", ErrorMessage = e.Message };
                        }
                        CursusInstantie instantie = new CursusInstantie { Cursus = cursus, Startdatum = datum };
                        try
                        {
                            instantie.Validate();
                        }
                        catch (ValidationException e)
                        {
                            throw new IllegalFormatException { ErrorCode = "IF002", ErrorMessage = e.Message };
                        }
                        cursussen.Add(instantie);
                    }
                }

            }
            catch (IllegalFormatException e)
            {
                importmodel.validationError = e;
                return View(importmodel);
            }

            var cursussenFiltered = FilterOnDate(cursussen, startdatum, einddatum);
            var result = _agent.ApiV1CursusPost(cursussenFiltered);

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

        private string ValidateFormat(string text, string regex, ref int linenumber)
        {
            linenumber++;
            if (!Regex.IsMatch(text, regex))
            {
                throw new IllegalFormatException { ErrorCode = "IF001", ErrorMessage = $"Regel {linenumber} is niet volgens formaat" };
            }
            return text.Substring(text.IndexOf(':') + 1).Trim();
        }

        private DateTime parseTime(string time)
        {
            return DateTime.ParseExact(time, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private int GetWeeknumberFrom(DateTime time)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            return currentCulture.Calendar.GetWeekOfYear(
                        time,
                        currentCulture.DateTimeFormat.CalendarWeekRule,
                        currentCulture.DateTimeFormat.FirstDayOfWeek
                );
        }

        private IList<CursusInstantie> FilterOnDate(IList<CursusInstantie> list, DateTime? begindatum, DateTime? einddatum)
        {
            if (begindatum != null)
            {
                list = list.Where(ci => {
                    DateTime time = parseTime(ci.Startdatum);
                    return time.AddDays(ci.Cursus.Duur) >= begindatum;
                    }).ToList();
            }
            if (einddatum != null)
            {
                list = list.Where(ci => parseTime(ci.Startdatum) <= einddatum).ToList();
            }
            return list;
        }
    }
}