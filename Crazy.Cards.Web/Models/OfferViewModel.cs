using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crazy.Cards.Web.Models
{
    public class OfferViewModel
    {
       

        public string CardName { get; set; }

        public string CardDescription { get; set; }

        public decimal CardAPR { get; set; }
        public int BalanceTransferOfferDuration { get; set; }

        public int PurchaseOfferDuration { get; set; }

        public int CreditLimit { get; set; }

        public string CardImage { get; set; }

    }
}