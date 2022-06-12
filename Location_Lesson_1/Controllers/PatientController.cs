using CoronaApp.Dal.Models;
using CoronaApp.Services.Repositories;
using Location_Lesson_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientrepository _IPatientrepository;

        public PatientController(IPatientrepository IPatientrepository)
        {
            _IPatientrepository = IPatientrepository;
        }
        [HttpGet]   
        public async Task<List<Patient>> GetAllPatients()
        {
            return await _IPatientrepository.GetAllPatients();
        }
        [HttpGet("name/{name}")]
        public async Task<Patient> GetPatientByName(string name)
        {
            return await _IPatientrepository.GetPatientByName(name);
        }
        [HttpPost("id/{id}")]
        public async Task<List<Patient>> AddPatient([FromBody]Patient patient, [FromRoute]string id)
        {
            return await _IPatientrepository.AddPatient(patient, id);
        }

        [HttpDelete("id/{id}")]
        public async Task<List<Patient>> DeletePatient( string id)
        {
            return await _IPatientrepository.DeletePatient(id);
        }
    }
}
