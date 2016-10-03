using DataAccessLayer.DomainModel;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Service
{
    public class ApplicantService : Repository<Applicant>, IApplicantService
    {
        //SMSDBContext objOfSMSDBContext = new SMSDBContext();
        //public IQueryable<StudentManageSystemGroup> GetSmsGroup()
        //{
        //    return objOfSMSDBContext.SmsGroup;
        //}
        //public bool Save(StudentManageSystemGroup SmsGroup)
        //{
        //    objOfSMSDBContext.SmsGroup.Add(SmsGroup);
        //    objOfSMSDBContext.SaveChanges();
        //    return true;
        //}
    }
}
