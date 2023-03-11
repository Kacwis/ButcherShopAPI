namespace ButcherShop.Models
{
    public class Customer : Person
    {
        public DateTime FirstOrderDate { get; set; }

        public double Discount { get; set; }

    }
}
