
using Crazy.Cards.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Crazy.Cards.Core.Models;
using Crazy.Cards.Core;

namespace Crazy.Cards.Web.Controllers
{
    public class CardOffersController : ApiController
    {
        private readonly ICardsRepository repository;
        public CardOffersController(ICardsRepository repo)
        {
            this.repository = repo;
        }
        // GET api/values
        [Route("api/Offers")]
        public IEnumerable<OfferViewModel> PostOffers(CustomerViewModel model)
        {
            var cardOffers =  repository.GetCards(model.EmploymentStatus, model.AnnualIncome);
            return Map(cardOffers);
            

        }

        private IEnumerable<OfferViewModel> Map(IEnumerable<CreditCard> cardOffers)
        {
            List<OfferViewModel> viewModelList = new List<OfferViewModel>();
            foreach (var r in cardOffers)
            {
                viewModelList.Add(new OfferViewModel() {
                     BalanceTransferOfferDuration =r.BalanceTransferOfferDuration,
                      CardAPR = r.APR,
                      CardDescription =r.CardDescription,
                      CardImage =r.CardImage,
                       CardName = r.CardName,
                      CreditLimit=r.CreditLimit,
                      PurchaseOfferDuration =r.PurchaseOfferDuration 

                });

            }

            return viewModelList;
            
        }

       
    }
}
