using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneProject.Data;
using TechZone.Web.ViewModels.Shop;

namespace TechZone.Services.Data.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(string userId, int productId);
        Task RemoveFromCartAsync(int cartItemId);
        Task<IEnumerable<CartViewModel>> GetCartItemsAsync(string userId);
    }
}
