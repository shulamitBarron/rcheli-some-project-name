using System.ComponentModel.DataAnnotations;

namespace Location_Lesson_1.Models
{
    public class Patient
    {
        public string PatientId { get; set; }

        public string PatientName { get; set; }
        public List<Location> locationList { get; set; }
        public Patient(string PatientId, string PatientName, List<Location> locationList)
        {
            this.PatientId = PatientId;
            this.PatientName = PatientName;
            this.locationList = locationList;
        }
    }
}
