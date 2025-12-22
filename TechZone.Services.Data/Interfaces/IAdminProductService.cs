using TechZone.Web.ViewModels.Admin.Models;

namespace TechZone.Services.Data.Interfaces
{
    public interface IAdminProductService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllBrandsAsync();

        Task CreateCpuAsync(AddCpuViewModel model);
        Task CreateGpuAsync(AddGpuViewModel model);
        Task CreateMotherboardAsync(AddMotherboardViewModel model);
        Task CreatePowerSupplyAsync(AddPowerSupplyViewModel model);
        Task CreateRamAsync(AddRamViewModel model);
        Task CreateStorageDriveAsync(AddStorageDriveViewModel model);
        Task CreateCaseAsync(AddCaseViewModel model);
        Task CreateDisplayAsync(AddDisplayViewModel model);
        Task CreateKeyboardAsync(AddKeyboardViewModel model);
        Task CreateMouseAsync(AddMouseViewModel model);
    }
}