namespace PatientInformationPortalView.Models
{
    public class ResponseModel
    {
        public bool isSuccess { get; set; }
        public string messsage { get; set; }
        public dynamic data { get; set; }
        public SavePatientInformationViewModel pdata { get; set; }
        public int status { get; set; }
    }
}
