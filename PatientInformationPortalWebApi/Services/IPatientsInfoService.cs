using PatientInformationPortal.Models;

namespace PatientInformationPortal.Services
{
    public interface IPatientsInfoService
    {
        List<DiseaseInformation> GetDiseaseInformationList();
        List<NCDs> GetNCDsList();
        List<Allergies> GetAllergiesList();
        List<PatientInformationViewModel> GetPatientInformationsList();
        ResponseData SavePatientInformation(SavePatientInformation objPI);
        ResponseData GetPatientInformation(PatientInformationViewModel objPI);
        ResponseData DeletePatientInformation(PatientInformationViewModel objPI);
    }
}
