using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using sedes.Data;
using sedes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sedes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private readonly SedesContext _dbContext;

        public PersonController(ILogger<PersonController> logger, SedesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {

            return _dbContext.Person.ToList();
        }


        [HttpPut]
        public IActionResult Put(string ExtRef)
        {
            try
            {
                var person = new Person { ExtRef = ExtRef };
                var dbResult = _dbContext.Person.Add(person);
                _dbContext.SaveChanges();
                return new OkObjectResult(dbResult.Entity);
            }
            catch (InvalidOperationException)
            {
                return new BadRequestObjectResult("");
            }
            catch (DbUpdateException e)
            {
                //TODO: should not expose Error Message to Caller
                return new BadRequestObjectResult(e.InnerException?.Message);
            }
        }
    }
}
