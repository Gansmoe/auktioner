using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace auktioner.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fyll i ett artikelnamn")]
        [Display(Name = "Artikelnamn")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fyll i en beskrivning")]
        [Display(Name = "Beskrivning")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fyll i ett produktID")]
        [Display(Name = "ProduktID")]
        [StringLength(9)]
        [RegularExpression(@"^[A-Z]{3}\d{6}$", ErrorMessage = "Felaktigt ID, ett ID ska ha tre versaler följt av sex siffror - exempel: ABC123456")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "Fyll i ett årtal")]
        [Display(Name = "Tillverkningsår")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Fyll i ett inköpspris")]
        [Display(Name = "Inköpspris")]
        public int BuyPrice { get; set; }

        [Required(ErrorMessage = "Fyll i ett utgångspris")]
        [Display(Name = "Utgångspris")]
        public int StartPrice { get; set; }

        [Required(ErrorMessage = "Fyll i ett slutpris")]
        [Display(Name = "Slutpris")]
        public int EndPrice { get; set; }

        [Required(ErrorMessage = "Fyll i en kategori")]
        [Display(Name = "Kategori")]
        public string Category { get; set; }

        public bool InStock { get; set; } = true;

    }
}
