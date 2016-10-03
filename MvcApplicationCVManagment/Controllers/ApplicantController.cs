using DataAccessLayer.DomainModel;
using DataAccessLayer.Service;
using MvcApplicationCVManagment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplicationCVManagment.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly ISmsGroupService _smsGroupService;
        private readonly IApplicantService _applicantService;

        private string path;

        public ApplicantController(ISmsGroupService smsGroupService, IApplicantService applicantService)
        {
            _smsGroupService = smsGroupService;
            _applicantService = applicantService;
        }
        public ActionResult Index()
        {
            ApplicantModel model = new ApplicantModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase pdfFile, ApplicantModel Model)
        {
            Applicant applicantDomainModel = new Applicant();

            if (pdfFile!=null)
            {
                //path = AppDomain.CurrentDomain.BaseDirectory + "/ApplicantCV/";
                //string filename = Path.GetFileName(Request.Files[upload].FileName);
                //Request.Files[upload].SaveAs(Path.Combine(path, filename));
                var fileName = Path.GetFileName(pdfFile.FileName);
                path = Path.Combine(Server.MapPath("~/ApplicantCV/"), fileName);
                pdfFile.SaveAs(path);
            }

            if (ModelState.IsValid)
            {
                applicantDomainModel.FirstName = Model.FirstName;
                applicantDomainModel.LastName = Model.LastName;
                applicantDomainModel.Email = Model.Email;
                applicantDomainModel.Phone = Model.Phone;
                applicantDomainModel.Address = Model.Address;
                applicantDomainModel.PostalCode = Model.PostalCode;
                applicantDomainModel.City = Model.City;
                applicantDomainModel.InterestAnimalProduction = Model.InterestAnimalProduction;
                applicantDomainModel.InterestBusiness = Model.InterestBusiness;
                applicantDomainModel.InterestHr = Model.InterestHr;
                applicantDomainModel.InterestIt = Model.InterestIt;
                applicantDomainModel.InterestJura = Model.InterestJura;
                applicantDomainModel.InterestEconomy = Model.InterestEconomy;
                applicantDomainModel.InterestPlanets = Model.InterestPlanets;
                applicantDomainModel.InterestOthers = Model.InterestOthers;
                applicantDomainModel.Status = Model.Status;
                applicantDomainModel.LinkedInUrl = Model.LinkedInUrl;
                applicantDomainModel.CV = path;
                applicantDomainModel.AcceptTerms = Model.AcceptTerms;

                _applicantService.Insert(applicantDomainModel);
            }

            return View();
        }
    }
}
