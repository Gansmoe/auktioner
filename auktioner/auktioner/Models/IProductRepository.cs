using System.Collections.Generic;


namespace auktioner.Models
{
    public interface IProductRepository
    {
        IEnumerable<Products> AllProducts { get; }
        public bool IsEndPriceLower(int buyPrice, int endPrice);
    }
}
