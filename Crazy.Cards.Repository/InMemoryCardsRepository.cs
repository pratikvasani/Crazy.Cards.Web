using Crazy.Cards.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crazy.Cards.Core.Enumerations;
using Crazy.Cards.Core.Models;

namespace Crazy.Cards.Repository
{
    public class InMemoryCardsRepository : ICardsRepository
    {
        private static IEnumerable<CreditCard> _cardsTable;
        private static IEnumerable<CardEligibility> _cardsEligibilityCriteriaTable;
        static InMemoryCardsRepository()
        {
            List<CreditCard> cards = new List<CreditCard>();
            CreditCard offer = new CreditCard();
            offer.CardId = 1;
            offer.CardName = "Anywhere Card";
            offer.CardDescription = "The card available to anyone , anywhere.";
            offer.APR = 33.9M;
            offer.BalanceTransferOfferDuration = 0;
            offer.PurchaseOfferDuration = 0;
            offer.CreditLimit = 300;
            offer.CardImage = "/img/portfolio/cake.png";
            offer.EligibilityCriteria = null;

            CreditCard offerStudent = new CreditCard();
            offerStudent.CardId = 2;
            offerStudent.CardName = "Student life credit card";
            offerStudent.CardDescription = "The student life credit card is specially for students.";
            offerStudent.APR = 18.9M;
            offerStudent.BalanceTransferOfferDuration = 0;
            offerStudent.PurchaseOfferDuration = 6;
            offerStudent.CreditLimit = 1200;
            offerStudent.CardImage = "/img/portfolio/circus.png";

            CreditCard offerEmp = new CreditCard();
            offerEmp.CardId = 3;
            offerEmp.CardName = "Liquid card";
            offerEmp.CardDescription = "For the working professional.";
            offerEmp.APR = 33.3M;
            offerEmp.BalanceTransferOfferDuration = 12;
            offerEmp.PurchaseOfferDuration = 6;
            offerEmp.CreditLimit = 3000;
            offerEmp.CardImage = "/img/portfolio/safe.png";

            List<CardEligibility> eligibilityCriteria = new List<CardEligibility>() {
                new CardEligibility() {
                    CardEligibilityId = 1, CardId = 1, EmploymentStatus = 0, MinimumAnualIncome = 0
                },
                new CardEligibility() {
                    CardEligibilityId = 1, CardId = 1, EmploymentStatus = 1, MinimumAnualIncome = 0
                },
                new CardEligibility() {
                    CardEligibilityId = 1, CardId = 1, EmploymentStatus = 2, MinimumAnualIncome = 0
                },
                new CardEligibility() {
                    CardEligibilityId = 1, CardId = 1, EmploymentStatus = 3, MinimumAnualIncome = 0
                },
                  new CardEligibility() {
                    CardEligibilityId = 1, CardId = 1, EmploymentStatus = 4, MinimumAnualIncome = 0
                },
                new CardEligibility() {
                    CardEligibilityId = 1, CardId = 2, EmploymentStatus = 2, MinimumAnualIncome = 0
                },
                                new CardEligibility() {
                    CardEligibilityId = 2, CardId = 3, EmploymentStatus = 2, MinimumAnualIncome = 1600
                },

                new CardEligibility() {
                    CardEligibilityId = 2, CardId = 3, EmploymentStatus = 3, MinimumAnualIncome = 1600
                },
                  new CardEligibility() {
                    CardEligibilityId = 2, CardId = 3, EmploymentStatus = 4, MinimumAnualIncome = 1600
                }
            };
            cards.Add(offer);
            cards.Add(offerStudent);
            cards.Add(offerEmp);


            _cardsTable = cards;

            _cardsEligibilityCriteriaTable = eligibilityCriteria.AsEnumerable();

        }
        public IEnumerable<CreditCard> GetCards(EmploymentStatus empStatus, decimal annualIncome)
        {
            var eligibleCards = from criteria in _cardsEligibilityCriteriaTable
                                where criteria.EmploymentStatus == (int)empStatus
                                where annualIncome >= criteria.MinimumAnualIncome
                                join card in _cardsTable on criteria.CardId equals card.CardId
                                select card;


            return eligibleCards.AsEnumerable();
        }
    }
}
