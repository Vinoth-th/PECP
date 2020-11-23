using Microsoft.Extensions.Logging;
using PromotionEngine.Contracts.Constants;

namespace PromotionEngine.Contracts.Models
{
    public static class UnitPriceForSKU
    {
        public static int GetPrice(char itemId, ILogger logger)
        {
            switch (itemId)
            {
                case 'A':
                    return PromotionEngineConstants.ProductA;

                case 'B':
                    return PromotionEngineConstants.ProductB;

                case 'C':
                    return PromotionEngineConstants.ProductC;

                case 'D':
                    return PromotionEngineConstants.ProductD;

                default:
                {
                    logger.LogWarning($"Ignoring the Invalid char '{itemId}' for calculating the order value.");
                    return 0;
                }
            }
        }
    }
}