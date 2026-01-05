using TechZone.Web.ViewModels.Shop; 

namespace TechZone.Web.ViewModels.Order
{
    public class CheckoutViewModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string? OrderNote { get; set; }

        public decimal TotalAmount { get; set; }

        public List<CartViewModel> Items { get; set; } = new List<CartViewModel>();
    }
}