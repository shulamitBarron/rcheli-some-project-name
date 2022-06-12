using Location_Lesson_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Repositories
{
    public interface IPatientrepository
    {
        Task<List<Patient>> GetAllPatients();
        Task <Patient> GetPatientByName(string name);
        Task<List<Patient>> AddPatient(Patient patients,string id);
        Task<List<Patient>> DeletePatient(string id);

    }
}
