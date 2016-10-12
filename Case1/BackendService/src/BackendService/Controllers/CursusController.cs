using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendService.Repository;
using Microsoft.AspNetCore.Mvc;
using BackendService.Entities;
using BackendService.Exceptions;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendService.Controllers
{
    [Route("api/v1/[controller]")]
    public class CursusController : Controller
    {
        private IRepository<CursusInstantie, int> _repository;

        public CursusController(IRepository<CursusInstantie, int> repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public IEnumerable<CursusInstantie> Get()
        {
            return _repository.FindAll();
        }

        [HttpGet("{id}")]
        public CursusInstantie Get(int id)
        {
            return _repository.FindById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody, Bind("Id,Cursus,Startdatum")]IEnumerable<CursusInstantie> cursus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var c in cursus)
                    {
                        _repository.Insert(c);
                    }
                    return Ok();
                }
                catch (Exception)
                {
                    var serverError = new FunctionalError { ErrorCode = "MC8001", ErrorMessage = "Unable to insert due to some server error" };
                    return BadRequest(serverError);
                }
            }

            var error = new FunctionalError { ErrorCode = "MC8000", ErrorMessage = "Monument does not have the required properties" };
            return BadRequest(error);
        }
    }
}
