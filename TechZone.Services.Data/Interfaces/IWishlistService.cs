using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZone.Web.ViewModels.Admin.Models;

namespace TechZone.Services.Data.Interfaces
{
    public interface IWishlistService
    {
        Task AddToWishlistAsync(string userId, int productId);
        Task RemoveFromWishlistAsync(string userId, int productId);
        Task<IEnumerable<ProductAllViewModel>> GetUserWishlistAsync(string userId);
    }
}
