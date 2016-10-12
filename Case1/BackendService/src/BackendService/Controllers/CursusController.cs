using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendService.Repository;
using Microsoft.AspNetCore.Mvc;
using BackendService.Entities;
using BackendService.Exceptions;
using System.Net;
using BackendService.Models;

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
        [ProducesResponseType(typeof(PostSuccess), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(PostFailure), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]IEnumerable<CursusInstantie> cursus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int numberOfTimesInsertedSuccessfully = 0;
                    foreach (var c in cursus)
                    {
                        try
                        {
                            _repository.Insert(c);
                            numberOfTimesInsertedSuccessfully++;
                        }
                        catch (DuplicateItemException)
                        {
                            // Do nothing.
                        }
                    }
                    return Ok(new PostSuccess { Total = cursus.Count(), Inserted = numberOfTimesInsertedSuccessfully});
                }
                catch (Exception)
                {
                    var serverError = new PostFailure { ErrorCode = "CC8001", ErrorMessage = "Unable to insert due to some server error" };
                    return BadRequest(serverError);
                }
            }

            var error = new PostFailure { ErrorCode = "CI8000", ErrorMessage = "CursusInstantie does not have the required properties" };
            return BadRequest(error);
        }
    }
}
