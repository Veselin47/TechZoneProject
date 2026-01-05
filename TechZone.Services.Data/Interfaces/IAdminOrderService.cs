using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZone.Web.ViewModels.Admin.Models;

namespace TechZone.Services.Data.Interfaces
{
    namespace TechZone.Services.Contracts
    {
        public interface IAdminOrderService
        {
            Task<IEnumerable<OrderAdminViewModel>> GetAllOrdersAsync();
            Task<OrderDetailsAdminViewModel> GetOrderDetailsAsync(int id);
            Task UpdateOrderStatusAsync(int id, string newStatus);
        }
    }
}
