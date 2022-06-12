using Location_Lesson_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoronaApp.Services.Repositories;
using Moq;

namespace Location_Lesson_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _IlocationRepository;
        private readonly Mock<ILocationRepository> _mock ;

        public LocationController(ILocationRepository IlocationRepository)
        {
            _IlocationRepository = IlocationRepository;
        }
       

        [HttpGet]
        public async Task<IEnumerable<Location>> Get()
        {
            return await _IlocationRepository.GetAllLocatin();
        }

        [HttpGet("id/{id}")]
        public async Task<IEnumerable<Location>> GetById(string id)
        {
            return await _IlocationRepository.GetLocationById(id);
        }

        [HttpGet("city/{city}")]
        public async Task<IEnumerable<Location>> Get(string city)
        {
            return await _IlocationRepository.GetLocatinByCity(city);
        }

        [HttpPost]
        public async  Task<List<Location>> Post(string id, [FromBody] List<Location> location)
        {
            if (await _IlocationRepository.AddLocation(id, location) != null)
                return location;
            return null;
        }

    }
}
