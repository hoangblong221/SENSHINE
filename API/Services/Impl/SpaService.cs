using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Impl
{
    public class SpaService : ISpaService
    {
        private readonly SenShineSpaContext _dbContext;
        public SpaService(SenShineSpaContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Service> CreateServiceAsync(Service services)
        {
            await _dbContext.Services.AddAsync(services);
            await _dbContext.SaveChangesAsync();
            return services;
        }

        public async Task<Service> DeleteServiceAsync(int IdSer)
        {
            var existingService = await _dbContext.Services.FirstOrDefaultAsync(x => x.IdSer == IdSer);
            if (existingService == null)
            {
                return null;
            }
            _dbContext.Services.Remove(existingService);
            await _dbContext.SaveChangesAsync();
            return existingService;
        }

        public async Task<Service> EditServiceAsync(int IdSer, Service services)
        {
            var existingService = await _dbContext.Services.FirstOrDefaultAsync(x => x.IdSer == IdSer);
            if (existingService == null)
            {
                return null;
            }
            existingService.ServiceName = services.ServiceName;
            existingService.Description = services.Description;
            await _dbContext.SaveChangesAsync(); // Save db sau khi sua

            return existingService;
        }

        public async Task<Service> FindServiceWithItsId(int IdSer)
        {
            return await _dbContext.Services.FirstOrDefaultAsync(x => x.IdSer == IdSer);
        }


        public async Task<List<Service>> GetAllServiceAsync()
        {
            return await _dbContext.Services.ToListAsync();
        }
    }
}

    
