using System;
using Xunit;
using auktioner.Models;
using System.Linq;

namespace auktioner_test
{
    public class UnitTest1
    {
        [Fact]
        public void EndPriceLowerThanBuyPrice()
        {
            MockProductRepository mockProductRepository = new MockProductRepository();

            var product = new Products { BuyPrice = 2000, EndPrice = 1000 };

            Assert.True(mockProductRepository.IsEndPriceLower(product.BuyPrice, product.EndPrice));
        }

        [Fact]
        public void GetAllCategories()
        {
            var mockCategoryRepository = new MockCategoryRepository();

            var expectedValue = 2;
            var actualValue = mockCategoryRepository.AllCategories.Count();

            var category = mockCategoryRepository.AllCategories.FirstOrDefault(c => c.Name == "Test");
            var actualValue2 = category.Name;

            Assert.Equal(expectedValue, actualValue);
            Assert.Contains("Test", actualValue2);
            Assert.DoesNotContain("Test2", actualValue2);

        }
    }
}
