using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy.Cards.Core.DomainModels
{
    public class CreditCard
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public string CardDescription { get; set; }

        public decimal APR { get; set; }
        public int BalanceTransferOfferDuration { get; set; }
        public int PurchaseOfferDuration { get; set; }
        public int CreditLimit { get; set; }
        public string CardImage { get; set; }

        public IEnumerable<CardEligibility> EligibilityCriteria { get; set; }

    }
}
