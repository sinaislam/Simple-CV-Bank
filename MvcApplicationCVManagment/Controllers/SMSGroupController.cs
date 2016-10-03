using DataAccessLayer.Service;
using DataAccessLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplicationCVManagment.Models;

namespace MvcApplicationCVManagment.Controllers
{
    public class SMSGroupController : ApiController
    {
        private readonly ISmsGroupService _smsGroupService;

        public SMSGroupController(ISmsGroupService smsGroupService)
        {
            _smsGroupService = smsGroupService;
        }

        public IHttpActionResult Post(StudentManageSystemGroup SmsGroup)
        {
            _smsGroupService.Insert(SmsGroup);

            return Ok();
        }

        [Route("api/SMSGroup/{pageNumber}")]
        public IHttpActionResult Get(int pageNumber)
        {
            SMSGroupViewModel objOfSMSGroupViewModel = new SMSGroupViewModel();
            objOfSMSGroupViewModel.TotalItem = _smsGroupService.FindAll().Count();
            objOfSMSGroupViewModel.SmsGroup = _smsGroupService.FindAll().OrderBy(x=>x.Id).Skip((pageNumber - 1) * 10).Take(10).ToList();

            return Ok(objOfSMSGroupViewModel);
        }
    }
}
