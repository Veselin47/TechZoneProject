using TechZone.Web.ViewModels.Admin.Models;

namespace TechZone.Services.Data.Interfaces
{
    public interface IAdminProductService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllBrandsAsync();

        Task CreateCpuAsync(AddCpuViewModel model); 
        Task<AddCpuViewModel> GetCpuForEditAsync(int id);
        Task EditCpuAsync(int id, AddCpuViewModel model);

        Task CreateGpuAsync(AddGpuViewModel model);
        Task<AddGpuViewModel> GetGpuForEditAsync(int id);
        Task EditGpuAsync(int id, AddGpuViewModel model);

        Task CreateMotherboardAsync(AddMotherboardViewModel model);
        Task<AddMotherboardViewModel> GetMotherboardForEditAsync(int id);
        Task EditMotherboardAsync(int id, AddMotherboardViewModel model); 

        Task CreateRamAsync(AddRamViewModel model);
        Task<AddRamViewModel> GetRamForEditAsync(int id);
        Task EditRamAsync(int id, AddRamViewModel model);

        Task CreatePowerSupplyAsync(AddPowerSupplyViewModel model);
        Task<AddPowerSupplyViewModel> GetPowerSupplyForEditAsync(int id);
        Task EditPowerSupplyAsync(int id, AddPowerSupplyViewModel model);

        Task CreateStorageDriveAsync(AddStorageDriveViewModel model);
        Task<AddStorageDriveViewModel> GetStorageDriveForEditAsync(int id);
        Task EditStorageDriveAsync(int id, AddStorageDriveViewModel model);

        Task CreateCaseAsync(AddCaseViewModel model);
        Task<AddCaseViewModel> GetCaseForEditAsync(int id);
        Task EditCaseAsync(int id, AddCaseViewModel model);

        Task CreateDisplayAsync(AddDisplayViewModel model); 
        Task<AddDisplayViewModel> GetDisplayForEditAsync(int id);
        Task EditDisplayAsync(int id, AddDisplayViewModel model);


        Task CreateKeyboardAsync(AddKeyboardViewModel model);
        Task<AddKeyboardViewModel> GetKeyboardForEditAsync(int id);
        Task EditKeyboardAsync(int id, AddKeyboardViewModel model);

  
        Task CreateMouseAsync(AddMouseViewModel model);
        Task<AddMouseViewModel> GetMouseForEditAsync(int id);
        Task EditMouseAsync(int id, AddMouseViewModel model);

        Task<IEnumerable<ProductAllViewModel>> GetAllProductsAsync();

        Task DeleteProductAsync(int id);
    }
}