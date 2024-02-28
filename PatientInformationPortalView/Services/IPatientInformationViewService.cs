using PatientInformationPortalView.Models;

namespace PatientInformationPortalView.Services
{
    public interface IPatientInformationViewService
    {
        List<PatientInformationViewModel> GetDiseaseInformationList();
        List<PatientInformationViewModel> GetNCDsList();
        List<PatientInformationViewModel> GetAllergiesList();
        List<PatientInformationViewModel> GetPatientInformationsList();
        ResponseModel SavePatientInformation(SavePatientInformationViewModel objPI);
        ResponseModel GetPatientInformation(int PatientsInfoId);
        ResponseModel DeletePatientInformation(int id);
    }
}
