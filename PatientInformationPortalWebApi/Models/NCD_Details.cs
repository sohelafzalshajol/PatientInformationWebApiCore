using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortal.Models
{
    public class NCD_Details
    {
        [Key]
        public int NCD_DetailsId { get; set; }

        [ForeignKey("PatientsInformation")]
        public int PatientsInfoId { get; set; }

        //[ForeignKey("NCDs")]
        public int NCDId { get; set; }
        public virtual PatientsInformation patientsInformation { get; set; }
        //public virtual NCDs nCDs { get; set; }

    }
}
