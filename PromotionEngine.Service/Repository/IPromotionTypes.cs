using System.Collections.Generic;
using PromotionEngine.Contracts.Models;

namespace PromotionEngine.Service.Repository
{
    public interface IPromotionTypes
    {
        List<PromotionType> GetPromotionTypes();
    }
}