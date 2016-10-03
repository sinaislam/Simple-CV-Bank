using DataAccessLayer.DomainModel;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Service
{
    public interface ISmsGroupService : IRepository<StudentManageSystemGroup>
    {
        //bool Save(StudentManageSystemGroup SmsGroup);
        //IQueryable<StudentManageSystemGroup> GetSmsGroup();
    }
}
