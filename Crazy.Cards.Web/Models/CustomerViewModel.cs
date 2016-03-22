using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crazy.Cards.Web.Models
{
    public class CustomerViewModel
    {
        public int Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DOB { get; set; }
        public int EmploymentStatus { get; set; }

        public string HouseNumber { get; set; }
        public string Street { get; set; }

        public string PostCode { get; set; }
    }
}