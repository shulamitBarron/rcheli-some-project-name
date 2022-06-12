using Location_Lesson_1.Models;
using Microsoft.Extensions.Logging;
using CoronaApp.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Models
{
    public class PatientRepository: IPatientrepository
    {
        private readonly ILogger<PatientRepository> _logger;
        public PatientRepository(ILogger<PatientRepository> logger)
        {
            _logger = logger;
        }
       
        public async Task<List<Patient>> GetAllPatients()
        {
            _logger.LogInformation("GetAllPatients function called");
            return await Task.FromResult(DB.PatientsList);
        }
        

        public async Task<Patient> GetPatientByName(string name)
        {
            _logger.LogInformation($"GetPatientByName function called with {name} name");

            return await Task.FromResult(DB.PatientsList.Find(patientName=>patientName.PatientName==name));
        }

        public async Task<List<Patient>> AddPatient(Patient patient, string id)
        {
            try
            {
                Patient p = DB.PatientsList.First(patient => patient.PatientId == id);
                DB.PatientsList.Add(patient);
                _logger.LogInformation($" patient {id} was successfully added!!!");
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(DB.PatientsList);
        }

        public async Task<List<Patient>> DeletePatient(string id)
        {
            try
            {
                Patient p = DB.PatientsList.First(patient => patient.PatientId == id);
                DB.PatientsList.Remove(p);
                _logger.LogInformation($" patient {id} was successfully deleted!!!");
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(DB.PatientsList);
        }

        
    }
}
