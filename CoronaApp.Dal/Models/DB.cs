using CoronaApp.Services.Repositories;
using Location_Lesson_1.Models;

namespace CoronaApp.Dal
{
    public  class DB
    {
        public List<Location> LocationList = new List<Location>();
        static List<Location> location1 = new List<Location>()
        {
            new Location(){ City = "Jerusalem", StartDate = new DateTime(2020 / 05 / 18), EndDate = new DateTime(2020/05/18), description = "central station" },
            new Location(){ City = "Beni Brak", StartDate = new DateTime(2020 / 06 / 13), EndDate = new DateTime(2020/05/18), description = "restaurant" }
        };
        static List<Location> location2 = new List<Location>()
        {
            new Location() { City = "Elad", StartDate = new DateTime(2020 / 04 / 12), EndDate = new DateTime(2020 / 05 / 18), description = "Hospital " },
            new Location() { City = "Tel Aviv", StartDate = new DateTime(2020 / 10 / 10), EndDate = new DateTime(2020 / 05 / 18), description = "Hotel" }
        };
        static List<Location> location3 = new List<Location>()
        {
            new Location() { City = "Petach Tikva", StartDate = new DateTime(2020 / 05 / 02), EndDate = new DateTime(2020 / 09 / 01), description = "school" },
            new Location() { City = "Zfat", StartDate = new DateTime(2020 / 03 / 18), EndDate = new DateTime(2020 / 05 / 19), description = "Doctor" }
        };
        public static  List<Patient> PatientsList { get; set; } = new List<Patient>()
        {
            new Patient("111","Cohen",location1),
            new Patient("222","Levi",location2),
            new Patient("333","Naaman",location3)
        };
    }
}
