using System;
using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindServiceHN.Core.ServicesStatusManager;

namespace FindServiceHn.Core.ServicesStatusManager
{
    public class ServicesStatusManager : IServicesStatusManager
    {
        private readonly IRepository<ServicesStatus> servicesstatusRepository;

        public ServicesStatusManager(IRepository<ServicesStatus> servicesstatusRepository,
             IJwtUtils jwtUtils,
             IOptions<AppSettings> appSettings)
        {
            this.servicesstatusRepository = servicesstatusRepository;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;

        }

        public async Task<IEnumerable<ServicesStatus>> GetAllAsync()
        {
            return await this.servicesstatusRepository.All().ToListAsync();
        }

         public ServicesStatus GetById(int id)
        {
            var servicesstatus = this.servicesstatusRepository.Find(id);
            if (servicesstatus == null) throw new KeyNotFoundException("not found");
            return servicesstatus;
        }

        public async Task<bool> DeleteServicesStatusAsync(int id)
        {
            try
            {
                var servicesstatus = this.GetById(id);
                this.servicesstatusRepository.Delete(servicesstatus);
                await this.servicesstatusRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<ServicesStatus> UpdateServicesStatusAsync(ServicesStatus servicesstatus)
        {
            try
            {
                var serivcesstatusToEdit = this.GetById(servicesstatus.IdServicesStatus);
                serivcesstatusToEdit.IStatus = servicesstatus.IStatus;
                serivcesstatusToEdit.Description = servicesstatus.Description;

                var result = this.servicesstatusRepository.Update(serivcesstatusToEdit);
                await this.servicesstatusRepository.SaveChangesAsync();
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<ServicesStatus> CreateServicesStatusAsync(ServicesStatusDTO servicesstatus)
        {
            if (servicesstatus != null)
            {
                var newservicesstatus = new ServicesStatus 
                {
                    IStatus = servicesstatus.IStatus,
                    Description = servicesstatus.Description,
                   
                };

                var result = this.servicesstatusRepository.Create(newservicesstatus);
                await this.servicesstatusRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    
    }

}