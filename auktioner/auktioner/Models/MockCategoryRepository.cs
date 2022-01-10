using System.Collections.Generic;

namespace auktioner.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category { Id = 1, Name = "Test"},
                new Category { Id = 2, Name = "Test2"},
            };
    }
}
