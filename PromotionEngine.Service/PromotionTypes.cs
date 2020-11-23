using System.Collections.Generic;
using PromotionEngine.Contracts.Models;
using PromotionEngine.Service.Repository;
using PromotionEngine.Contracts.Constants;

namespace PromotionEngine.Service
{
    public class PromotionTypes : IPromotionTypes
    {
        public List<PromotionType> GetPromotionTypes()
        {
            var promotionTypes = new List<PromotionType>
            {
                new PromotionType
                {
                    CartDetails = new List<CartDetail> {
                    new CartDetail {SKUId = 'A', NoOfUnits = 3}},
                    Price = PromotionEngineConstants.PromotionA
                },
                new PromotionType
                {
                    CartDetails = new List<CartDetail> {
                    new CartDetail {SKUId = 'B', NoOfUnits = 2}},
                    Price = PromotionEngineConstants.PromotionB
                },
                new PromotionType
                {
                    CartDetails = new List<CartDetail> {
                    new CartDetail {SKUId = 'C', NoOfUnits = 1},
                    new CartDetail {SKUId = 'D', NoOfUnits = 1}},
                    Price = PromotionEngineConstants.PromotionCD
                }
            };

            return promotionTypes;
        }
    }
}