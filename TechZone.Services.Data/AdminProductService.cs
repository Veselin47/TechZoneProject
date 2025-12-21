using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZone.Services.Data.Interfaces;
using TechZoneProject.Data;
using TechZoneProject.Data.Models;
using TechZone.Web.ViewModels.Admin.Models;

namespace TechZone.Services.Data
{
    public class AdminProductService : IAdminProductService
    {
        private readonly ApplicationDbContext dbContext;

        public AdminProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllBrandsAsync()
        {
            return await this.dbContext.Brands
                .Select(b => new KeyValuePair<string, string>(b.Id.ToString(), b.Name))
                .ToListAsync();
        }

        public async Task CreateCpuAsync(AddCpuViewModel model)
        {
            Cpu cpu = new Cpu
            {
                // Общи (от Product)
                Name = model.Name,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                BrandId = model.BrandId,
                StockQuantity = model.StockQuantity,
                IsDeleted = false, 

                // Специфични за CPU (новите)
                Series = model.Series,
                Socket = model.Socket,
                PhysicalCores = model.PhysicalCores,
                LogicalCores = model.LogicalCores,
                BaseFrequencyGhz = model.BaseFrequencyGhz,
                TurboFrequencyGhz = model.TurboFrequencyGhz,
                Cache = model.Cache,
                WarrantyMonths = model.WarrantyMonths,
                HasBoxCooler = model.HasBoxCooler
            };

            await this.dbContext.Cpus.AddAsync(cpu);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
