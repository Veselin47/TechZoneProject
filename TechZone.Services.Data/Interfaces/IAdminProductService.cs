using TechZone.Web.ViewModels.Admin.Models;

namespace TechZone.Services.Data.Interfaces
{
    public interface IAdminProductService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllBrandsAsync();

        Task CreateCpuAsync(AddCpuViewModel model);

    }
}