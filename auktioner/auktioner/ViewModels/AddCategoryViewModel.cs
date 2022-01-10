using auktioner.Models;
using System.Collections.Generic;

namespace auktioner.ViewModels
{
    public class AddCategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public string Name { get; set; }

    }
}
