using DataAccessLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationCVManagment.Models
{
    public class SMSGroupViewModel
    {
        public SMSGroupViewModel()
        {
            SmsGroup = new List<StudentManageSystemGroup>();
        }
        public List<StudentManageSystemGroup> SmsGroup { get; set; }
        public int TotalItem { get; set; }

    }
}