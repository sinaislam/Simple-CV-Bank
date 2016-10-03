using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DomainModel
{
    public class JOBManageDBContext : DbContext
    {
        public JOBManageDBContext()
            : base("JobManageContext")
        {
        }

        public virtual DbSet<StudentManageSystemGroup> SmsGroup { get; set; }
        public virtual DbSet<Applicant> Applicant { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
