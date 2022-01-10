using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace auktioner.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Products> AllProducts
        {
            get 
            { 
                return _appDbContext.Products; 
            }
        }

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
