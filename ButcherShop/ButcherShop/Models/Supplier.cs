using System.ComponentModel.DataAnnotations.Schema;

namespace ButcherShop.Models
{
    public class Supplier : Person 
    {
        [ForeignKey("DeliveryCompany")]
        public int DeliveryCompanyId { get; set; }
        
        public DeliveryCompany DeliveryCompany { get; set; }    
    }
}
