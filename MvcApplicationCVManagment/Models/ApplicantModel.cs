using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplicationCVManagment.Models
{
    public class ApplicantModel
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "The Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Your must provide a PostalCode")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }


        [Required(ErrorMessage = "The City is required")]
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

        [Required(ErrorMessage = "The LinkedInUrl is required")]
        public string LinkedInUrl { get; set; }

        public string CV { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Please tick the Term and Condition")]
        public bool AcceptTerms { get; set; }
    }
}