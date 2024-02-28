using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortal.Models
{
    public class PatientsInformation
    {
        [Key]
        public int PatientsInfoId { get; set; }

        //[Required(ErrorMessage = "Please Enter Patient Name")]
        //[Display(Name = "Patient Name")]
        [StringLength(50)]
        public string PatientsName { get; set; }

        [ForeignKey("DiseaseInformation")]
        public int DiseaseId { get; set; }

        public bool IsEpilepsy { get; set; }
        public virtual DiseaseInformation diseaseInformation { get; set; }
        public virtual ICollection<NCD_Details> nCD_Details { get; set; }
        public virtual ICollection<Allergies_Details> allergies_Details { get; set; }
    }
}
