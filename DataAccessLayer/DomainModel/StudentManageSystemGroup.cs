using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DomainModel
{
    [Table("StudentGroup")]
    public class StudentManageSystemGroup
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
