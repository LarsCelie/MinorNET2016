using System;
using Microsoft.AspNetCore.Mvc;
namespace FrontEnd.Controllers
{

    public class CursusController : Controller
    {
        public CursusController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Import()
        {
            return View();
        }
    }

}