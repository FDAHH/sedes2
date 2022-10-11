using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using sedes.Data;
using sedes.Models;
using sedes.Models.Frontend;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sedes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ODataController
    {

        private readonly ILogger<RoomController> _logger;
        private readonly SedesContext _dbContext;
        private readonly IMapper _mapper;

        public RoomController(ILogger<RoomController> logger, SedesContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<ZRoom> Get()
        {

            return _dbContext.Room.ProjectTo<ZRoom>(_mapper.ConfigurationProvider);


        }

        [HttpPut()]
        public IActionResult Put([FromBody] ZRoom zroom)
        {
            try
            {
                var room = _mapper.Map<Room>(zroom);

                _dbContext.Room.Add(room);
                _dbContext.SaveChanges();
                return new AcceptedResult();
            }
            catch (InvalidOperationException)
            {
                return new BadRequestObjectResult("Cant find Building with Id:"  );
            }
            catch (DbUpdateException e)
            {
                //TODO: should not expose Error Message to Caller
                return new BadRequestObjectResult(e.InnerException?.Message);
            }
        }
    }
}
