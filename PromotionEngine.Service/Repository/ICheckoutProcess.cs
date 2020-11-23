using System.Collections.Generic;
using PromotionEngine.Contracts.Models;

namespace PromotionEngine.Service.Repository
{
    public interface ICheckoutProcess
    {
        double CalculateTotalOrderValue(List<char> cart);

        List<CartDetail> CalculateNoOfItemsInCart(List<char> cart);

        double ApplyingPromotionTypes(List<CartDetail> cartDetails, List<PromotionType> promotionTypes, double orderValue);

        double CalculateCartItemsOrderValue(List<CartDetail> cartDetails, double orderValue);
    }
}