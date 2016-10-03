using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccessLayer.DomainModel
{
    [Table("ApplicantDetails")]
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public bool InterestAnimalProduction { get; set; }

        public bool InterestBusiness { get; set; }

        public bool InterestHr { get; set; }

        public bool InterestIt { get; set; }
        public bool InterestJura { get; set; }
        public bool InterestEconomy { get; set; }
        public bool InterestPlanets { get; set; }

        public bool InterestOthers { get; set; }

        public string Status { get; set; }

        public string LinkedInUrl { get; set; }

        public string CV { get; set; }

        public bool AcceptTerms { get; set; }
    }
}