namespace PatientInformationPortal.Models
{
    public class ResponseData
    {
        public bool isSuccess { get; set; }
        public string messsage { get; set; }
        public dynamic data { get; set; }
        public SavePatientInformation pdata { get; set; }
        public int status { get; set; }
    }
}
