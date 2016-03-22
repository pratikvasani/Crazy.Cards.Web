using Crazy.Cards.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Crazy.Cards.Web.Controllers
{
    public class CardOffersController : ApiController
    {
        // GET api/values
        [Route("api/Offers")]
        public IEnumerable<OfferViewModel> PostOffers(CustomerViewModel model)
        {
            OfferViewModel offer = new OfferViewModel();
            offer.CardName = "Anywhere Card";
            offer.CardDescription = "The card available to anyone , anywhere.";
            offer.CardAPR = 33.9M;
            offer.BalanceTransferOfferDuration = 0;
            offer.PurchaseOfferDuration = 0;
            offer.CreditLimit = 300;
            offer.CardImage = "/img/portfolio/cake.png";

            OfferViewModel offerStudent = new OfferViewModel();
            offerStudent.CardName = "Student life credit card";
            offerStudent.CardDescription = "The student life credit card is specially for students.";
            offerStudent.CardAPR = 18.9M;
            offerStudent.BalanceTransferOfferDuration = 0;
            offerStudent.PurchaseOfferDuration = 6;
            offerStudent.CreditLimit = 1200;
            offerStudent.CardImage = "/img/portfolio/circus.png";

            OfferViewModel offerEmp = new OfferViewModel();
            offerEmp.CardName = "Liquid card";
            offerEmp.CardDescription = "For the working professional.";
            offerEmp.CardAPR = 33.3M;
            offerEmp.BalanceTransferOfferDuration = 12;
            offerEmp.PurchaseOfferDuration = 6;
            offerEmp.CreditLimit = 3000;
            offerEmp.CardImage = "/img/portfolio/safe.png";



            return new List<OfferViewModel>() { offer ,offerStudent , offerEmp };

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
