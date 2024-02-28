namespace PatientInformationPortal.Models
{
    public class SavePatientInformation
    {
        public int PatientsInfoId { get; set; }
        public int[] allergies { get; set; }
        public int diseasesId { get; set; }
        public bool epilepsy { get; set; }
        public int[] otherNCDs { get; set; }
        public string patientName { get; set; }
        public string AuthKey { get; set; }
    }
}
