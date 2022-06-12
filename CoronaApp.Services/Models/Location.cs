using CoronaApp.Services.Repositories;

namespace Location_Lesson_1.Models
{
    public class Location
    {       
        public string City { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public string description { get; set; } 
    }
}
