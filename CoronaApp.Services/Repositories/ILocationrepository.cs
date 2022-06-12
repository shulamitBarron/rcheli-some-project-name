using Location_Lesson_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Repositories
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocatin();
        Task<List<Location>> GetLocationById(string id); 
        Task<List<Location>> GetLocatinByCity(string city);
        Task<IEnumerable<Location>> AddLocation(string id, List<Location>location);
    }
}
