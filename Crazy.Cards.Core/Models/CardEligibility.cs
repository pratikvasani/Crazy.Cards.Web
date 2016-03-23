using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy.Cards.Core.Models
{
    public class CardEligibility
    {
        public int CardId { get; set; }
        public int EmploymentStatus { get; set; }

        public int MinimumAnualIncome { get; set; }
        public int CardEligibilityId { get; set; }
    }
}
