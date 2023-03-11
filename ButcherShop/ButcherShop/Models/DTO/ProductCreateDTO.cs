using System.ComponentModel.DataAnnotations;

namespace ButcherShop.Models.DTO
{
    public class ProductCreateDTO
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]

        public double Price { get; set; }

        [Required]
        [Range(10, 500)]
        public int Quantity { get; set; }

    }
}
