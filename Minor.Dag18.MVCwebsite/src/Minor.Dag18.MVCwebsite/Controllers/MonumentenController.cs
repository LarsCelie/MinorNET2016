using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Minor.Dag18.MVCwebsite.Agents;
using Minor.Dag18.MVCwebsite.Entities;

namespace Minor.Dag18.MVCwebsite.Controllers
{
    public class MonumentenController : Controller
    {
        private IMonumentAgent _agent;

        public MonumentenController(IMonumentAgent agent)
        {
            _agent = agent;
        }

        public ActionResult Index()
        {
            IEnumerable<Monument> model = _agent.FindAll();
            return View(model);
        }
        
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            _agent.Delete(id.Value);
            return RedirectToAction("Index");
        }

        public ActionResult Insert(Monument m)
        {
            _agent.Insert(m);
            return RedirectToAction("Index");
        }
    }

}