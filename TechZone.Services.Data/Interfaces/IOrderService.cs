using TechZone.Web.ViewModels.Order;

namespace TechZone.Services.Contracts
{
    public interface IOrderService
    {
        Task<CheckoutViewModel> GetCheckoutDataAsync(string userId);
        Task<bool> CreateOrderAsync(string userId, CheckoutViewModel model);
    }
}