﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplicationCVManagment.Models
{
    public class ApplicantDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Interest { get; set; }

        public string Status { get; set; }

        public string LinkedInUrl { get; set; }

        public string CV { get; set; }
    }
}