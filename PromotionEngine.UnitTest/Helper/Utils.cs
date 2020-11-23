using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using PromotionEngine.Contracts.Models;
using PromotionEngine.Contracts.Constants;
using PromotionEngine.Service;

namespace PromotionEngine.UnitTest.Helper
{
    public static class Utils
    {
        public static ILogger<CheckoutProcess> GetLogger()
        {
            var logger = new Mock<ILogger<CheckoutProcess>>();
            return logger.Object;
        }

        public static List<PromotionType> GetPromotionTypes()
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

        public static List<PromotionType> GetPromotionTypeWithPercentage()
        {
            var promotionTypes = new List<PromotionType>
            {
                new PromotionType
                {
                    CartDetails = new List<CartDetail> {
                    new CartDetail {SKUId = 'A', NoOfUnits = 1}},
                    Percentage = 40,
                },
                new PromotionType
                {
                    CartDetails = new List<CartDetail> {
                    new CartDetail {SKUId = 'B', NoOfUnits = 2}},
                    Price = 45
                },
                new PromotionType
                {
                    CartDetails = new List<CartDetail> {
                    new CartDetail {SKUId = 'C', NoOfUnits = 1},
                    new CartDetail {SKUId = 'D', NoOfUnits = 1}},
                    Price = 30
                }
            };
            return promotionTypes;
        }

        public static List<PromotionType> GetPromotionTypeWithPercentageForSameItem()
        {
            var promotionTypes = new List<PromotionType>
            {
                 new PromotionType
                {
                    CartDetails = new List<CartDetail> {
                    new CartDetail {SKUId = 'A', NoOfUnits = 2}},
                    Price = 30
                },
                new PromotionType
                {
                    CartDetails = new List<CartDetail> {
                    new CartDetail {SKUId = 'A', NoOfUnits = 1}},
                    Percentage = 40,
                }
            };
            return promotionTypes;
        }

    }
}
