using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortal.Models
{
    public class Allergies_Details
    {
        [Key]
        public int Allergies_DetailsId { get; set; }

        [ForeignKey("PatientsInformation")]
        public int PatientsInfoId { get; set; }

        //[ForeignKey("Allergies")]
        public int AllergyId { get; set; }
        public virtual PatientsInformation patientsInformation { get; set; }
        //public virtual Allergies allergies { get; set; }
    }
}
