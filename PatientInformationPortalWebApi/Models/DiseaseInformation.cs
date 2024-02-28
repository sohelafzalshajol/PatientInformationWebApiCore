using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortal.Models
{
    public class DiseaseInformation
    {
        [Key]
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
        public virtual PatientsInformation patientsInformation { get; set; }
    }
}
