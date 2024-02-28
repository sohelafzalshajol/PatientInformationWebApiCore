using Microsoft.EntityFrameworkCore;
using PatientInformationPortal.Models;
using System;

namespace PatientInformationPortal.Services
{
    public class PatientsInfoService : IPatientsInfoService
    {
        private PIPContext _context;
        public PatientsInfoService(PIPContext context)
        {
            _context = context;
        }
        public List<DiseaseInformation> GetDiseaseInformationList()
        {
            List<DiseaseInformation> DiseaseInfoList;
            try
            {
                DiseaseInfoList = _context.Set<DiseaseInformation>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return DiseaseInfoList;
        }

        public List<NCDs> GetNCDsList()
        {
            List<NCDs> NCDList;
            try
            {
                NCDList = _context.Set<NCDs>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return NCDList;
        }

        public List<Allergies> GetAllergiesList()
        {
            List<Allergies> allergiesList;
            try
            {
                allergiesList = _context.Set<Allergies>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return allergiesList;
        }

        public List<PatientInformationViewModel> GetPatientInformationsList()
        {
            List<PatientInformationViewModel> piList;
            try
            {
                piList = _context.Set<PatientsInformation>()
                .Include(p => p.diseaseInformation)
                .Select(p => new PatientInformationViewModel
                {
                    PatientsInfoId = p.PatientsInfoId,
                    PatientsName = p.PatientsName,
                    IsEpilepsy = p.IsEpilepsy,
                    DiseaseName = p.diseaseInformation.DiseaseName,
                })
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return piList;
        }

        public ResponseData SavePatientInformation(SavePatientInformation objPI)
        {
            ResponseData res = new ResponseData();
            if (objPI.PatientsInfoId > 0)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        int count1 = 0, count2 = 0, count3 = 0;
                        PatientsInformation PatientInfo = _context.PatientsInformation.Find(objPI.PatientsInfoId);
                        PatientInfo.PatientsName = objPI.patientName;
                        PatientInfo.IsEpilepsy = objPI.epilepsy;
                        PatientInfo.DiseaseId = objPI.diseasesId;
                        _context.Update(PatientInfo);
                        count1 = _context.SaveChanges();

                        List<NCD_Details> ncdDetails = _context.NCD_Details.Where(ncd => ncd.PatientsInfoId == objPI.PatientsInfoId).ToList();
                        if (ncdDetails.Count > 0)
                        {
                            _context.NCD_Details.RemoveRange(ncdDetails);
                            count2 = _context.SaveChanges();
                        }

                        List<NCD_Details> ncdDetails1 = new List<NCD_Details>();
                        foreach (int item in objPI.otherNCDs)
                        {
                            ncdDetails1.Add(new NCD_Details()
                            {
                                PatientsInfoId = PatientInfo.PatientsInfoId,
                                NCDId = item
                            });
                        }
                        _context.AddRange(ncdDetails1);
                        count2 = _context.SaveChanges();

                        List<Allergies_Details> algDetails = _context.Allergies_Details.Where(al => al.PatientsInfoId == objPI.PatientsInfoId).ToList();
                        if (algDetails.Count > 0)
                        {
                            _context.Allergies_Details.RemoveRange(algDetails);
                            count3 = _context.SaveChanges();
                        }

                        List<Allergies_Details> algDetails1 = new List<Allergies_Details>();
                        foreach (int item in objPI.allergies)
                        {
                            algDetails1.Add(new Allergies_Details()
                            {
                                PatientsInfoId = PatientInfo.PatientsInfoId,
                                AllergyId = item
                            });
                        }
                        _context.AddRange(algDetails1);
                        count3 = _context.SaveChanges();

                        transaction.Commit();

                        res.isSuccess = true;
                        res.messsage = "Success";
                        res.status = 200;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        res.isSuccess = false;
                        res.messsage = ex.Message;
                    }
                }
            }
            else
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        int count1 = 0, count2 = 0, count3 = 0;
                        PatientsInformation PatientInfo = new PatientsInformation()
                        {
                            PatientsName = objPI.patientName,
                            DiseaseId = objPI.diseasesId,
                            IsEpilepsy = objPI.epilepsy
                        };
                        _context.Add<PatientsInformation>(PatientInfo);
                        count1 = _context.SaveChanges();
                        if (count1 > 0 && objPI.otherNCDs.Length > 0)
                        {
                            List<NCD_Details> ncdDetails = new List<NCD_Details>();
                            foreach (int item in objPI.otherNCDs)
                            {
                                ncdDetails.Add(new NCD_Details()
                                {
                                    PatientsInfoId = PatientInfo.PatientsInfoId,
                                    NCDId = item
                                });
                            }
                            _context.AddRange(ncdDetails);
                            count2 = _context.SaveChanges();
                        }
                        if (count2 > 0 && objPI.allergies.Length > 0)
                        {
                            List<Allergies_Details> algDetails = new List<Allergies_Details>();
                            foreach (int item in objPI.allergies)
                            {
                                algDetails.Add(new Allergies_Details()
                                {
                                    PatientsInfoId = PatientInfo.PatientsInfoId,
                                    AllergyId = item
                                });
                            }
                            _context.AddRange(algDetails);
                            count3 = _context.SaveChanges();
                        }

                        transaction.Commit();

                        res.isSuccess = true;
                        res.messsage = "Success";
                        res.status = 201;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        res.isSuccess = false;
                        res.messsage = ex.Message;
                    }
                }
            }
            return res;
        }

        public ResponseData GetPatientInformation(PatientInformationViewModel objPI)
        {
            ResponseData res = new ResponseData();
            res.pdata = new SavePatientInformation();
            try
            {
                PatientsInformation PatientInfo = _context.PatientsInformation.Find(objPI.PatientsInfoId);
                res.pdata.PatientsInfoId = PatientInfo.PatientsInfoId;
                res.pdata.patientName = PatientInfo.PatientsName;
                res.pdata.diseasesId = PatientInfo.DiseaseId;
                res.pdata.epilepsy = PatientInfo.IsEpilepsy;


                List<NCD_Details> ncdDetails = _context.NCD_Details.Where(ncd => ncd.PatientsInfoId == objPI.PatientsInfoId).ToList();
                res.pdata.otherNCDs = new int[ncdDetails.Count];
                for (int i = 0; i < ncdDetails.Count; i++)
                {
                    res.pdata.otherNCDs[i] = ncdDetails[i].NCDId;
                }

                List<Allergies_Details> algDetails = _context.Allergies_Details.Where(al => al.PatientsInfoId == objPI.PatientsInfoId).ToList();
                res.pdata.allergies = new int[algDetails.Count];
                for (int i = 0; i<algDetails.Count; i++)
                {
                    res.pdata.allergies[i]= algDetails[i].AllergyId;
                }


                res.isSuccess = true;
                res.messsage = "Success";
                res.status = 200;
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.messsage = ex.Message;
            }
            return res;
        }

        public ResponseData DeletePatientInformation(PatientInformationViewModel objPI)
        {
            ResponseData res = new ResponseData();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int count1 = 0, count2 = 0, count3 = 0;
                    PatientsInformation PatientInfo = _context.PatientsInformation.Find(objPI.PatientsInfoId);
                    _context.Remove(PatientInfo);
                    count1 = _context.SaveChanges();

                    List<NCD_Details> ncdDetails = _context.NCD_Details.Where(ncd => ncd.PatientsInfoId == objPI.PatientsInfoId).ToList();
                    if (ncdDetails.Count > 0)
                    {
                        _context.NCD_Details.RemoveRange(ncdDetails);
                        count2 = _context.SaveChanges();
                    }

                    List<Allergies_Details> algDetails = _context.Allergies_Details.Where(al => al.PatientsInfoId == objPI.PatientsInfoId).ToList();
                    if (algDetails.Count > 0)
                    {
                        _context.Allergies_Details.RemoveRange(algDetails);
                        count3 = _context.SaveChanges();
                    }

                    transaction.Commit();

                    res.isSuccess = true;
                    res.messsage = "Success";
                    res.status = 200;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    res.isSuccess = false;
                    res.messsage = ex.Message;
                }
            }
            return res;
        }

    }
}
