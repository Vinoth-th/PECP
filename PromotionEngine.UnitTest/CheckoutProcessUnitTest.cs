using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using PromotionEngine.Contracts.Models;
using PromotionEngine.Service.Repository;
using PromotionEngine.Service;
using PromotionEngine.UnitTest.Helper;
using Xunit;

namespace PromotionEngine.Test
{
    public class CheckoutProcessUnitTest
    {
        [Fact]
        public void SC1_UnitTest_PromotionEngine()
        {
            //Assign
            var cartItems = new List<char> { 'A', 'B', 'C' };
            var promotionTypesMock = new Mock<IPromotionTypes>();
            promotionTypesMock.Setup(x => x.GetPromotionTypes()).Returns(Utils.GetPromotionTypes());

            //Act
            var promotionEngineProcess = new PromotionEngine.Service.CheckoutProcess(promotionTypesMock.Object, Utils.GetLogger());
            var orderValue = promotionEngineProcess.CalculateTotalOrderValue(cartItems);

            //Assert
            Assert.Equal(100, orderValue);
        }

        [Fact]
        public void SC2_UnitTest_PromotionEngine()
        {
            //Assign
            var cartItems = new List<char> { 'A', 'B', 'C', 'A', 'A', 'A', 'A', 'B', 'B', 'B', 'B' };
            var promotionTypesMock = new Mock<IPromotionTypes>();
            promotionTypesMock.Setup(x => x.GetPromotionTypes()).Returns(Utils.GetPromotionTypes());

            //Act
            var promotionEngineProcess = new CheckoutProcess(promotionTypesMock.Object, Utils.GetLogger());
            var orderValue = promotionEngineProcess.CalculateTotalOrderValue(cartItems);

            //Assert
            Assert.Equal(370, orderValue);
        }

        [Fact]
        public void SC3_UnitTest_PromotionEngine()
        {
            //Act
            var cartItems = new List<char> { 'A', 'B', 'C', 'D', 'A', 'A', 'B', 'B', 'B', 'B' };
            var promotionTypesMock = new Mock<IPromotionTypes>();
            promotionTypesMock.Setup(x => x.GetPromotionTypes()).Returns(Utils.GetPromotionTypes());

            //Act
            var promotionEngineProcess = new CheckoutProcess(promotionTypesMock.Object, Utils.GetLogger());
            var orderValue = promotionEngineProcess.CalculateTotalOrderValue(cartItems);

            //Assert
            Assert.Equal(280, orderValue);
        }

        [Fact]
        public void SC4_UnitTest_PromotionEngine()
        {
            //Act
            var cartItems = new List<char> { 'A', 'B', 'C' };
            var promotionTypesMock = new Mock<IPromotionTypes>();
            promotionTypesMock.Setup(x => x.GetPromotionTypes()).Returns(Utils.GetPromotionTypeWithPercentage());

            //Act
            var promotionEngineProcess = new CheckoutProcess(promotionTypesMock.Object, Utils.GetLogger());
            var orderValue = promotionEngineProcess.CalculateTotalOrderValue(cartItems);

            //Assert
            Assert.Equal(70, orderValue);
        }

        [Fact]
        public void SC5_UnitTest_PromotionEngine_PromotionTypeWithPercentageForSameItem()
        {
            //Act
            var cartItems = new List<char> { 'A', 'A', 'A' };
            var promotionTypesMock = new Mock<IPromotionTypes>();
            promotionTypesMock.Setup(x => x.GetPromotionTypes()).Returns(Utils.GetPromotionTypeWithPercentageForSameItem());

            //Act
            var promotionEngineProcess = new CheckoutProcess(promotionTypesMock.Object, Utils.GetLogger());
            var orderValue = promotionEngineProcess.CalculateTotalOrderValue(cartItems);

            //Assert
            Assert.Equal(50, orderValue);
        }

        [Theory(DisplayName = "SC6_UnitTest_CalculateTotalOrderValue_WithInvalidString")]
        [InlineData("A,;,!", 50)]
        [InlineData(" ", 0)]
        [InlineData("1,2,3,4", 0)]
        [InlineData("F,E,G", 0)]
        [InlineData("A3C", 70)]
        public void SC61_Test_CalculateTotalOrderValue_WithInvalidString(string inputCartString, double expectedOrderValue)
        {
            //Act
            var cartItems = inputCartString.Replace(',', ' ').Replace(" ", "").ToCharArray().ToList();
            ;
            var promotionTypesMock = new Mock<IPromotionTypes>();
            promotionTypesMock.Setup(x => x.GetPromotionTypes()).Returns(Utils.GetPromotionTypes());

            //Act
            var promotionEngineProcess = new CheckoutProcess(promotionTypesMock.Object, Utils.GetLogger());
            var orderValue = promotionEngineProcess.CalculateTotalOrderValue(cartItems);

            //Assert
            Assert.Equal(expectedOrderValue, orderValue);
        }


    }
}
