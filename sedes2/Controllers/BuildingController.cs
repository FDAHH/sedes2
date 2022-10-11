using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using sedes.Data;
using sedes.Models;
using sedes.Models.Frontend;
using System;
using System.Linq;

namespace sedes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {

        private readonly ILogger<BuildingController> _logger;
        private readonly SedesContext _dbContext;
        private readonly IMapper _mapper;

        public BuildingController(ILogger<BuildingController> logger, SedesContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;

        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<ZBuilding> Get()
        {

            return _dbContext.Building
                .ProjectTo<ZBuilding>(_mapper.ConfigurationProvider);

        }

        [HttpPut]
        public IActionResult Put(string Name)
        {
            try
            {
                Building item = new Building
                {
                    Name = Name
                };
                var dbResult = _dbContext.Building.Add(item);
                _dbContext.SaveChanges();
                return new OkObjectResult(dbResult.Entity);
            }
            catch (InvalidOperationException)
            {
                return new BadRequestObjectResult("Cant find Building with Id:");
            }
            catch (DbUpdateException e)
            {
                //TODO: should not expose Error Message to Caller
                return new BadRequestObjectResult(e.InnerException?.Message);
            }
        }
    }
}
