using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PatientInformationPortalView.Models;
using System.Collections.Generic;
using System.Net;

namespace PatientInformationPortalView.Services
{
    public class PatientInformationViewService : IPatientInformationViewService
    {
        static string BaseURL = string.Format(@"http://localhost:5072/");
        static string AuthKey = "Shajol";
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private static readonly HttpClient client = new HttpClient();
        //public PatientInformationViewService(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}
        public List<PatientInformationViewModel> GetDiseaseInformationList()
        {
            List<PatientInformationViewModel> dData = new List<PatientInformationViewModel>();
            

            var url = BaseURL + "api/PatientsInformation/GetDiseaseInformationList/"+ AuthKey;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            try
            {
                //using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                //{
                //    string json = JsonConvert.SerializeObject(AuthKey);
                //    streamWriter.Write(json);
                //}
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    dynamic results = streamReader.ReadToEnd();
                    ResponseModel res = JsonConvert.DeserializeObject<ResponseModel>(results);
                    var jsonArray = res.data as JArray;
                    if (jsonArray != null)
                    {
                        dData = jsonArray.ToObject<List<PatientInformationViewModel>>();
                    }
                }
                return dData;
            }
            catch (Exception e)
            {
                return dData;
            }
        }

        public List<PatientInformationViewModel> GetNCDsList()
        {
            List<PatientInformationViewModel> ncdData = new List<PatientInformationViewModel>();
            

            var url = BaseURL + "api/PatientsInformation/GetNCDsList/" + AuthKey;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            try
            {
                //using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                //{
                //    string json = JsonConvert.SerializeObject(AuthKey);
                //    streamWriter.Write(json);
                //}
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    dynamic results = streamReader.ReadToEnd();
                    ResponseModel res = JsonConvert.DeserializeObject<ResponseModel>(results);
                    var jsonArray = res.data as JArray;
                    if (jsonArray != null)
                    {
                        ncdData = jsonArray.ToObject<List<PatientInformationViewModel>>();
                    }
                }
                return ncdData;
            }
            catch (Exception e)
            {
                return ncdData;
            }
        }

        public List<PatientInformationViewModel> GetAllergiesList()
        {
            List<PatientInformationViewModel> allergiesData = new List<PatientInformationViewModel>();
            

            var url = BaseURL + "api/PatientsInformation/GetAllergiesList/" + AuthKey;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            try
            {
                //using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                //{
                //    string json = JsonConvert.SerializeObject(AuthKey);
                //    streamWriter.Write(json);
                //}
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    dynamic results = streamReader.ReadToEnd();
                    ResponseModel res = JsonConvert.DeserializeObject<ResponseModel>(results);
                    var jsonArray = res.data as JArray;
                    if (jsonArray != null)
                    {
                        allergiesData = jsonArray.ToObject<List<PatientInformationViewModel>>();
                    }
                }
                return allergiesData;
            }
            catch (Exception e)
            {
                return allergiesData;
            }
        }

        public List<PatientInformationViewModel> GetPatientInformationsList()
        {
            List<PatientInformationViewModel> PlData = new List<PatientInformationViewModel>();


            var url = BaseURL + "api/PatientsInformation/GetPatientInformationsList/" + AuthKey;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    dynamic results = streamReader.ReadToEnd();
                    ResponseModel res = JsonConvert.DeserializeObject<ResponseModel>(results);
                    var jsonArray = res.data as JArray;
                    if (jsonArray != null)
                    {
                        PlData = jsonArray.ToObject<List<PatientInformationViewModel>>();
                    }
                }
                return PlData;
            }
            catch (Exception e)
            {
                return PlData;
            }
        }

        public ResponseModel SavePatientInformation(SavePatientInformationViewModel objPI)
        {
            objPI.AuthKey = AuthKey;
            objPI.allergies = objPI.allergies ?? new int[0];
            objPI.otherNCDs = objPI.otherNCDs ?? new int[0];
            ResponseModel res = new ResponseModel();
            var url = BaseURL + "api/PatientsInformation/SavePatientInformation";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(objPI);
                    streamWriter.Write(json);
                }
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    dynamic results = streamReader.ReadToEnd();
                    res = JsonConvert.DeserializeObject<ResponseModel>(results);
                }
                return res;
            }
            catch (Exception e)
            {
                return res;
            }
        }

        public ResponseModel GetPatientInformation(int PatientsInfoId)
        {
            PatientInformationViewModel objPI = new PatientInformationViewModel()
            {
                AuthKey = AuthKey,
                PatientsInfoId = PatientsInfoId,
                NCDName = "",
                DiseaseName = "",
                AllergyName = "",
                PatientsName = ""
            };
            ResponseModel res = new ResponseModel();
            var url = BaseURL + "api/PatientsInformation/GetPatientInformation";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(objPI);
                    streamWriter.Write(json);
                }
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    dynamic results = streamReader.ReadToEnd();
                    res = JsonConvert.DeserializeObject<ResponseModel>(results);
                }
                return res;
            }
            catch (Exception e)
            {
                return res;
            }
        }

        public ResponseModel DeletePatientInformation(int id)
        {
            PatientInformationViewModel objPI = new PatientInformationViewModel(){
                AuthKey = AuthKey,
                PatientsInfoId = id,
                NCDName="",
                DiseaseName="",
                AllergyName="",
                PatientsName=""
            };
            ResponseModel res = new ResponseModel();
            var url = BaseURL + "api/PatientsInformation/DeletePatientInformation";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(objPI);
                    streamWriter.Write(json);
                }
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    dynamic results = streamReader.ReadToEnd();
                    res = JsonConvert.DeserializeObject<ResponseModel>(results);
                }
                return res;
            }
            catch (Exception e)
            {
                return res;
            }
        }

    }
}
