using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortal.Models
{
    public class Allergies
    {
        [Key]
        public int AllergyId { get; set; }
        public string AllergyName { get; set; }
        //public virtual Allergies_Details allergies_Details { get; set; }
    }
}
