using System.ComponentModel.DataAnnotations;

namespace ButcherShop.Models.DTO
{
    public class CustomerCreateDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

    }
}
