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
    public class AdminController : Controller
    {
        private readonly ISmsGroupService _smsGroupService;
        private readonly IApplicantService _applicantService;

        public AdminController(ISmsGroupService smsGroupService, IApplicantService applicantService)
        {
            _smsGroupService = smsGroupService;
            _applicantService = applicantService;
        }

       [Authorize]
        public ActionResult CVBank(ApplicantAdminModel Model,int page = 1)
        {

            //ApplicantAdminModel objOfApplicantAdminModel = new ApplicantAdminModel();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Please Select", Value = "0" });
            list.Add(new SelectListItem() { Text = "AnimalProduction", Value = "1" });
            list.Add(new SelectListItem() { Text = "Business", Value = "2" });
            list.Add(new SelectListItem() { Text = "HR", Value = "3" });
            list.Add(new SelectListItem() { Text = "IT", Value = "4" });
            list.Add(new SelectListItem() { Text = "Jura", Value = "5" });
            list.Add(new SelectListItem() { Text = "Economy", Value = "6" });
            list.Add(new SelectListItem() { Text = "Planets", Value = "7" });
            list.Add(new SelectListItem() { Text = "Others", Value = "8" });

            var query = _applicantService.FindAll();


            if (Model.TalentOrInterest == "0")
            {

                if (!string.IsNullOrEmpty(Model.SearchEmail))
                {
                    query = query.Where(x => x.Email.Contains(Model.SearchEmail));
                }

                if (!string.IsNullOrEmpty(Model.SearchName))
                {
                    query = query.Where(x => x.FirstName.Contains(Model.SearchName) || x.LastName.Contains(Model.SearchName));
                }

                if (!string.IsNullOrEmpty(Model.Phone))
                {
                    query = query.Where(x => x.FirstName.Contains(Model.Phone));
                }

                var pager = new Pager(query.Count(), page);

                var viewModel = new ApplicantAdminModel
                {
                    TalentsList = list,
                    TalentOrInterest = Model.TalentOrInterest,
                    SearchEmail = Model.SearchEmail,
                    Applicants = query.OrderBy(x => x.Id).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList(),
                    Pager = pager
                };

                return View(viewModel);
            }

            else
            {
                if (Model.TalentOrInterest == "1")
                {
                    query=query.Where(x => x.InterestAnimalProduction == true);
                }
                if (Model.TalentOrInterest == "2")
                {
                    query = query.Where(x => x.InterestBusiness == true);
                }
                if (Model.TalentOrInterest == "3")
                {
                    query = query.Where(x => x.InterestHr == true);
                }
                if (Model.TalentOrInterest == "4")
                {
                    query = query.Where(x => x.InterestIt == true);
                }
                if (Model.TalentOrInterest == "5")
                {
                    query = query.Where(x => x.InterestJura == true);
                }
                if (Model.TalentOrInterest == "6")
                {
                    query = query.Where(x => x.InterestEconomy == true);
                }
                if (Model.TalentOrInterest == "7")
                {
                    query = query.Where(x => x.InterestPlanets == true);
                }
                if (Model.TalentOrInterest == "8")
                {
                    query = query.Where(x => x.InterestOthers == true);
                }

                if (!string.IsNullOrEmpty(Model.SearchEmail))
                {
                    query = query.Where(x => x.Email.Contains(Model.SearchEmail));
                }

                if (!string.IsNullOrEmpty(Model.SearchName))
                {
                    query = query.Where(x => x.FirstName.Contains(Model.SearchName) || x.LastName.Contains(Model.SearchName));
                }

                if (!string.IsNullOrEmpty(Model.Phone))
                {
                    query = query.Where(x => x.FirstName.Contains(Model.Phone));
                }

                var pager = new Pager(query.Count(), page);

                var viewModel = new ApplicantAdminModel
                {
                    TalentsList = list,
                    TalentOrInterest = Model.TalentOrInterest,
                    SearchEmail = Model.SearchEmail,
                    Applicants = query.OrderBy(x => x.Id).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList(),
                    Pager = pager
                };

                //objOfApplicantAdminModel.TotalItem = _applicantService.FindAll().Count();
                //objOfApplicantAdminModel.Applicants = _applicantService.FindAll().OrderBy(x => x.Id).Skip((page - 1) * 10).Take(10).ToList();

                //return Ok(objOfSMSGroupViewModel);

                return View(viewModel);
            }

        }


        [Authorize]
        public ActionResult Detail(int Id)
        {
            string interest = "";
            ApplicantDetailModel objOfApplicantAdminModel = new ApplicantDetailModel();
            Applicant applicantDomainModel = _applicantService.Find(Id);

            objOfApplicantAdminModel.Id = applicantDomainModel.Id;

            if (applicantDomainModel.InterestAnimalProduction)
            {
                interest = interest + "Animal,";
            }
            if (applicantDomainModel.InterestBusiness)
            {
                interest = interest + "Business,";
            }
            if (applicantDomainModel.InterestEconomy)
            {
                interest = interest + "Economy,";
            }
            if (applicantDomainModel.InterestHr)
            {
                interest = interest + "Hr,";
            }
            if (applicantDomainModel.InterestIt)
            {
                interest = interest + "It,";
            }
            if (applicantDomainModel.InterestJura)
            {
                interest = interest + "Jura,";
            }
            if (applicantDomainModel.InterestOthers)
            {
                interest = interest + "Others,";
            }
            if (applicantDomainModel.InterestPlanets)
            {
                interest = interest + "Planets,";
            }
            objOfApplicantAdminModel.Interest = interest.TrimEnd(',');
            objOfApplicantAdminModel.Interest = objOfApplicantAdminModel.Interest.TrimStart(',');
            objOfApplicantAdminModel.Name = applicantDomainModel.FirstName+" "+ applicantDomainModel.LastName;
            objOfApplicantAdminModel.Address = applicantDomainModel.Address;
            objOfApplicantAdminModel.Phone = applicantDomainModel.Phone;
            objOfApplicantAdminModel.Status = applicantDomainModel.Status;

            return View(objOfApplicantAdminModel);
        }

        [Authorize]
        public ActionResult Delete(int Id)
        {
            _applicantService.Delete(Id);
            return RedirectToAction("CVBank");
        }

        [Authorize]
        public ActionResult DownloadCV(int Id)
        {
            Applicant applicantDomainModel = _applicantService.Find(Id);
            string NameOfCv = applicantDomainModel.FirstName + "" + applicantDomainModel.LastName + "'CV";
            return File(applicantDomainModel.CV, "application/pdf", NameOfCv);
        }

        [Authorize]
        public ActionResult DownloadCVIndividual(int Id)
        {
            Applicant applicantDomainModel = _applicantService.Find(Id);
            string NameOfCv = applicantDomainModel.FirstName + "" + applicantDomainModel.LastName + "'CV";
            return File(applicantDomainModel.CV, "application/pdf", NameOfCv);
        }

    }
}
