using System.ComponentModel.DataAnnotations;
using auktioner.Models;

namespace auktioner.ViewModels
{
    public class AuctioneerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fyll i ett slutpris")]
        [Display(Name = "Slutpris")]
        public int EndPrice { get; set; }

        public bool InStock { get; set; }
    }
}
