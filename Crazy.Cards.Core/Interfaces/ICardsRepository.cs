using Crazy.Cards.Core.Enumerations;
using Crazy.Cards.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy.Cards.Core
{
    public interface ICardsRepository
    {
         IEnumerable<CreditCard> GetCards(EmploymentStatus empStatus, decimal annualIncome);
    }
}
