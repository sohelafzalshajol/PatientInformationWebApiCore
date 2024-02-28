using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalView.Models
{
    public class PatientInformationViewModel
    {
        public int PatientsInfoId { get; set; }
        public string PatientsName { get; set; }
        public int DiseaseId { get; set; }
        public bool IsEpilepsy { get; set; }
        public int AllergyId { get; set; }
        public string AllergyName { get; set; }
        public int Allergies_DetailsId { get; set; }
        public string DiseaseName { get; set; }
        public int NCDId { get; set; }
        public string NCDName { get; set; }
        public int NCD_DetailsId { get; set; }
        public string AuthKey { get; set; }
    }
}
