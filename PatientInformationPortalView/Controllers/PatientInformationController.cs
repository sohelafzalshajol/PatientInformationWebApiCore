using Microsoft.AspNetCore.Mvc;
using PatientInformationPortalView.Models;
using PatientInformationPortalView.Services;

namespace PatientInformationPortalView.Controllers
{
    public class PatientInformationController : Controller
    {
        IPatientInformationViewService _PatientInformationViewService;
        public PatientInformationController(IPatientInformationViewService PatientInformationViewService)
        {
            _PatientInformationViewService = PatientInformationViewService;
        }

        public IActionResult GetDiseaseInformationList()
        {
            try
            {

                var data = _PatientInformationViewService.GetDiseaseInformationList();
                if (data == null) return NotFound();

                var response = new ResponseModel();
                response.data = data;
                response.isSuccess = true;
                response.messsage = "Success";
                response.status = 200;
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IActionResult GetNCDsList()
        {
            try
            {

                var data = _PatientInformationViewService.GetNCDsList();
                if (data == null) return NotFound();

                var response = new ResponseModel();
                response.data = data;
                response.isSuccess = true;
                response.messsage = "Success";
                response.status = 200;
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IActionResult GetAllergiesList()
        {
            try
            {

                var data = _PatientInformationViewService.GetAllergiesList();
                if (data == null) return NotFound();

                var response = new ResponseModel();
                response.data = data;
                response.isSuccess = true;
                response.messsage = "Success";
                response.status = 200;
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IActionResult PatientInformations()
        {
            return View();
        }
        public IActionResult SavePatientInformation(SavePatientInformationViewModel objPI)
        {
            try
            {
                var data = _PatientInformationViewService.SavePatientInformation(objPI);
                if (data == null) return NotFound();

                var response = new ResponseModel();
                response.data = data.data;
                response.isSuccess = data.isSuccess;
                response.messsage = data.messsage;
                response.status = data.status;
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IActionResult GetPatientInformation(int PatientsInfoId)
        {
            try
            {
                var data = _PatientInformationViewService.GetPatientInformation(PatientsInfoId);
                if (data == null) return NotFound();

                var response = new ResponseModel();
                response.pdata = data.pdata;
                response.isSuccess = data.isSuccess;
                response.messsage = data.messsage;
                response.status = data.status;
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IActionResult DeletePatientInformation(int id)
        {
            try
            {
                var data = _PatientInformationViewService.DeletePatientInformation(id);
                if (data == null) return NotFound();

                var response = new ResponseModel();
                response.data = data.data;
                response.isSuccess = data.isSuccess;
                response.messsage = data.messsage;
                response.status = data.status;
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IActionResult LoadPatientInformation(int id)
        {
            return View();
        }

        public IActionResult GetPatientInformationsList()
        {
            try
            {

                var data = _PatientInformationViewService.GetPatientInformationsList();
                if (data == null) return NotFound();

                var response = new ResponseModel();
                response.data = data;
                response.isSuccess = true;
                response.messsage = "Success";
                response.status = 200;
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IActionResult PatientInformationsList()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
