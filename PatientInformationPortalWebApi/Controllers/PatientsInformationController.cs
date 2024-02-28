using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortal.Models;
using PatientInformationPortal.Services;

namespace PatientInformationPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsInformationController : ControllerBase
    {
        private string AuthKey;
        IPatientsInfoService _PatientsInfoService;
        public PatientsInformationController(IPatientsInfoService PatientsInfoService)
        {
            this.AuthKey = "Shajol";
            _PatientsInfoService = PatientsInfoService;
        }

        [HttpPost]
        [Route("[action]/{AuthKey}")]
        public IActionResult GetDiseaseInformationList(string AuthKey)
        {
            try
            {
                if (this.AuthKey == AuthKey)
                {

                    var data = _PatientsInfoService.GetDiseaseInformationList();
                    if (data == null) return NotFound();

                    var response = new ResponseData();
                    response.data = data;
                    response.isSuccess = true;
                    response.messsage = "Success";
                    response.status = 200;
                    return Ok(response);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]/{AuthKey}")]
        public IActionResult GetNCDsList(string AuthKey)
        {
            try
            {
                if (this.AuthKey == AuthKey)
                {

                    var data = _PatientsInfoService.GetNCDsList();
                    if (data == null) return NotFound();

                    var response = new ResponseData();
                    response.data = data;
                    response.isSuccess = true;
                    response.messsage = "Success";
                    response.status = 200;
                    return Ok(response);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]/{AuthKey}")]
        public IActionResult GetAllergiesList(string AuthKey)
        {
            try
            {
                if (this.AuthKey == AuthKey)
                {

                    var data = _PatientsInfoService.GetAllergiesList();
                    if (data == null) return NotFound();

                    var response = new ResponseData();
                    response.data = data;
                    response.isSuccess = true;
                    response.messsage = "Success";
                    response.status = 200;
                    return Ok(response);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]/{AuthKey}")]
        public IActionResult GetPatientInformationsList(string AuthKey)
        {
            try
            {
                if (this.AuthKey == AuthKey)
                {

                    var data = _PatientsInfoService.GetPatientInformationsList();
                    if (data == null) return NotFound();

                    var response = new ResponseData();
                    response.data = data;
                    response.isSuccess = true;
                    response.messsage = "Success";
                    response.status = 200;
                    return Ok(response);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SavePatientInformation([FromBody] SavePatientInformation objPI)
        {
            try
            {
                if (this.AuthKey == objPI.AuthKey)
                {

                    var data = _PatientsInfoService.SavePatientInformation(objPI);
                    if (data == null) return NotFound();

                    var response = new ResponseData();
                    response.data = data.data;
                    response.isSuccess = data.isSuccess;
                    response.messsage = data.messsage;
                    response.status = data.status;
                    return Ok(response);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetPatientInformation([FromBody] PatientInformationViewModel objPI)
        {
            try
            {
                if (this.AuthKey == objPI.AuthKey)
                {

                    var data = _PatientsInfoService.GetPatientInformation(objPI);
                    if (data == null) return NotFound();

                    var response = new ResponseData();
                    response.pdata = data.pdata;
                    response.isSuccess = data.isSuccess;
                    response.messsage = data.messsage;
                    response.status = data.status;
                    return Ok(response);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult DeletePatientInformation([FromBody] PatientInformationViewModel objPI)
        {
            try
            {
                if (this.AuthKey == objPI.AuthKey)
                {

                    var data = _PatientsInfoService.DeletePatientInformation(objPI);
                    if (data == null) return NotFound();

                    var response = new ResponseData();
                    response.data = data.data;
                    response.isSuccess = data.isSuccess;
                    response.messsage = data.messsage;
                    response.status = data.status;
                    return Ok(response);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
