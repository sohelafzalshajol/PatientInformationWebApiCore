using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortal.Models
{
    public class NCDs
    {
        [Key]
        public int NCDId { get; set; }
        public string NCDName { get; set; }
        //public virtual NCD_Details nCD_Details { get; set; }
    }
}
