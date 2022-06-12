using CoronaApp.Dal;
using CoronaApp.Services.Repositories;
using Location_Lesson_1.Models;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoronaApp.Dal
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ILogger <LocationRepository> _logger;   
        public LocationRepository(ILogger<LocationRepository> logger)
        {
            _logger= logger;
        }
        public async Task<List<Location>> GetAllLocatin()
        {
            _logger.LogInformation("I am Get All Locatin");
            return await Task.FromResult(DB.PatientsList.SelectMany(patient => patient.locationList).ToList());
        }

        public async Task<List<Location>> GetLocationById(string id)

        {
            if(id== null)
            {
                _logger.LogWarning("id is null");
            }
            return await Task.FromResult(DB.PatientsList.Where(patientId => patientId.PatientId == id).First().locationList);
        }

        public async Task<List<Location>> GetLocatinByCity(string city)
        {
            if(city== null)
            {
                _logger.LogWarning("city is null");
            }
            return await Task.FromResult(DB.PatientsList.SelectMany(patient => patient.locationList).Where(location => location.City == city).ToList());
        }

        public async Task<IEnumerable<Location>> AddLocation(string id, List<Location> location)
        {
            try
            {
                DB.PatientsList.Where(patient => patient.PatientId == id).First().locationList.AddRange(location);
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(location);

        }


    }
}
