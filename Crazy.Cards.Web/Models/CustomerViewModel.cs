using Crazy.Cards.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crazy.Cards.Web.Models
{
    public class CustomerViewModel
    {
        public Title Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DOB { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }

        public decimal AnnualIncome { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }

        public string PostCode { get; set; }
    }
}