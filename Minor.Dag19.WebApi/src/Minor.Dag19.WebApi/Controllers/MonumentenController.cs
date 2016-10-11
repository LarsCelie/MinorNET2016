using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minor.Dag19.WebApi.DAL;
using Minor.Dag19.WebApi.Entities;
using System.Net;
using Controllers;

namespace Minor.Dag19.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class MonumentenController : Controller
    {
        private IRepository<Monument, int> _repository;

        public MonumentenController(IRepository<Monument, int> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Monument> Get()
        {
            return _repository.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var obj =  _repository.Find(id);
                return Ok(obj);
            }
            catch (Exception)
            {
                var serverError = new FunctionalError { ErrorCode = "MC8001", ErrorMessage = "Unable to insert due to some server error" };
                return BadRequest(serverError);
            }
            
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FunctionalError), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody, Bind("Id,Naam,Hoogte")]Monument monument)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Insert(monument);
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody, Bind("Naam,Hoogte")]Monument monument)
        {
            monument.Id = id;
            _repository.Update(monument);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
