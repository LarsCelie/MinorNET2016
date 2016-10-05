using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minor.Dag19.WebApi.DAL;
using Minor.Dag19.WebApi.Entities;

namespace Minor.Dag19.WebApi.Controllers
{
    [Route("api/[controller]")]
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
        public Monument Get(int id)
        {
            return _repository.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody, Bind("Id,Naam,Hoogte")]Monument monument)
        {
            _repository.Insert(monument);
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
