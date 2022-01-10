using System.Collections.Generic;

namespace auktioner.Models
{
    public class MockProductRepository : IProductRepository
    {
        public IEnumerable<Products> AllProducts =>
            new List<Products>
            {
                new Products { Id = 1, Name = "Test", Category = "Test", BuyPrice = 2000, Description = "Test", EndPrice = 2500, ProductId = "ABC123456", StartPrice = 400, Year = 1991},
                new Products { Id = 2, Name = "Test", Category = "Test", BuyPrice = 3000, Description= "Test", EndPrice = 3500, ProductId = "ABC123456", StartPrice = 500, Year =1992},
            };
  

        public bool IsEndPriceLower(int buyPrice, int endPrice)
        {
            if (buyPrice > endPrice)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
