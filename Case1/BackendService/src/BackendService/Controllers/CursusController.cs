using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendService.Repository;
using Microsoft.AspNetCore.Mvc;
using BackendService.Entities;

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
            return _repository.FindBy(id);
        }

        public void Post(CursusInstantie cursus)
        {
            _repository.Insert(cursus);
        }
    }
}
