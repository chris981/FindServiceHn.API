using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.Models;
using FindServiceHN.Core.ProviderManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BCryptNet = BCrypt.Net.BCrypt;

namespace FindServiceHN.Core.ProviderManager
{
    public class ProviderManager : IProviderManager
    {
        private IRepository<Provider> ProviderRepository;
        private IRepository<ProviderEval> providerEvalRepository;
        private IRepository<ProviderPlanJob> providerPlanJobRepository;
        private IRepository<ProviderService> providerServiceRepository;

        public ProviderManager(
            IRepository<Provider> ProviderRepository,
            IRepository<ProviderEval> ProviderEvalRepository,
            IRepository<ProviderPlanJob> ProviderPlanJobRepository,
            IRepository<ProviderService> ProviderServiceRepository)
        {
            this.ProviderRepository = ProviderRepository;
            this.providerEvalRepository = ProviderEvalRepository;
            this.providerPlanJobRepository = ProviderPlanJobRepository;
            this.providerServiceRepository=ProviderServiceRepository;
        }
        #region"Provider"
        public async Task<IEnumerable<Provider>> GetAllAsync()
        {
            return await this.ProviderRepository.All().ToListAsync();
        }
        public async Task<Provider> CreateProviderAsync(ProviderDTO provider)
        {
            if (provider != null)
            {
                var newProvider = new Provider
                {
                    Email = provider.Email,
                    AtentionFirst = provider.AtentionFirst,
                    AtentionLast = provider.AtentionLast,
                    Country = provider.Country,
                    Company = provider.Company,
                    Department = provider.Department,
                    IdCategory = provider.IdCategory,
                    IdentificationCard = provider.IdentificationCard,
                    IdSubcategory = provider.IdSubcategory,
                    IndDelivery = provider.IndDelivery,
                    IndusCai = provider.IndusCai,
                    IStatus = provider.IStatus,
                    KeyValidation = provider.KeyValidation,
                    LastName = provider.LastName,
                    Municipality = provider.Municipality,
                    Name = provider.Name,
                    Password = BCryptNet.HashPassword(provider.Password),
                    Phone = provider.Phone,
                    ProfilePicture = provider.ProfilePicture,
                    ProfilePrincipal = provider.ProfilePrincipal,
                    QtyWorks = provider.QtyWorks,
                    RTN = provider.RTN,
                    Url = provider.Url,
                    UserType = provider.UserType,

                };

                var result = this.ProviderRepository.Create(newProvider);
                await this.ProviderRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<bool> DeleteProviderAsync(int id)
        {
            try
            {
                var provider = this.GetById(id);
               this.ProviderRepository.Delete(provider);
                await this.ProviderRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public async Task<Provider> UpdateProviderAsync(Provider provider)
        {
            try
            {
                var providerToEdit = this.GetById(provider.IdProvider);
                providerToEdit.Password = BCryptNet.HashPassword(provider.Password);
                providerToEdit.Phone = provider.Phone;
                providerToEdit.UserType = provider.UserType;
                providerToEdit.ProfilePicture = provider.ProfilePicture;
                providerToEdit.ProfilePrincipal = provider.ProfilePrincipal;
                providerToEdit.Name = provider.Name;
                providerToEdit.LastName = provider.LastName;
                providerToEdit.Country = provider.Country;
                providerToEdit.Municipality = provider.Municipality;


                var result = this.ProviderRepository.Update(providerToEdit);
                await this.ProviderRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Provider GetById(int id)
        {
            var provider = this.ProviderRepository.Find(id);
            if (provider == null) throw new KeyNotFoundException("provider not found");
            return provider;
        }
        #endregion

        #region"ProviderPlanJob"
         public async Task<IEnumerable<ProviderPlanJob>> GetProviderPlanJobAsync()
        {
            return await this.providerPlanJobRepository.All().ToListAsync();
        }
        public async Task<ProviderPlanJob> CreateProviderPlanJobAsync(ProviderPlanJobDTO providerPlanJob)
        {
            if (providerPlanJob != null)
            {
                var newProviderPlanJob = new ProviderPlanJob
                {
                    Amount= providerPlanJob.Amount,
                     Name= providerPlanJob.Name,
                     CreationDate= providerPlanJob.CreationDate,
                };


                var result = this.providerPlanJobRepository.Create(newProviderPlanJob);
                await this.providerPlanJobRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<bool> DeleteProviderPlanJobAsync(int id)
        {
            try
            {
                var providerPlanJob = this.GetProviderPlanJobById(id);
                this.providerPlanJobRepository.Delete(providerPlanJob);
                await this.providerPlanJobRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<ProviderPlanJob> UpdateProviderPlanJobAsync(ProviderPlanJob providerPlanJob)
        {
            try
            {
                var providerPlanJobToEdit = this.GetProviderPlanJobById(providerPlanJob.IdQtyWorks);
                providerPlanJobToEdit.Amount = providerPlanJob.Amount;
                providerPlanJobToEdit.Name = providerPlanJob.Name;
                providerPlanJobToEdit.CreationDate= providerPlanJob.CreationDate;

                var result = this.providerPlanJobRepository.Update(providerPlanJobToEdit);
                await this.providerPlanJobRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProviderPlanJob GetProviderPlanJobById(int id)
        {
            var providerPlanJob = this.providerPlanJobRepository.Find(id);
            if (providerPlanJob == null) throw new KeyNotFoundException("provider plan job not found");
            return providerPlanJob;
        }
        #endregion


        #region "providerService"
        public async Task<IEnumerable<ProviderService>> GetAllProviderServiceAsync()
        {
            return await this.providerServiceRepository.All().ToListAsync();
        }

        public async Task<ProviderService> CreateProviderServiceAsync(ProviderServiceDTO providerService)
        {
            if (providerService != null)
            {
                var newProviderService = new ProviderService
                {
                   Currency=providerService.Currency,
                   Description=providerService.Description,
                   IdServiceType=providerService.IdServiceType,
                   IStatus=providerService.IStatus,
                   Price=providerService.Price,
                   Product=providerService.Product,
                   ProductImage=providerService.ProductImage,
                   Shipping=providerService.Shipping,
                   TypeService=providerService.TypeService,
                };


                var result = this.providerServiceRepository.Create(newProviderService);
                await this.providerPlanJobRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public ProviderService GetProviderServiceById(int id)
        {
            var providerService = this.providerServiceRepository.Find(id);
            if (providerService == null) throw new KeyNotFoundException("provider service not found");
            return providerService;
        }

        public async Task<bool> DeleteProviderServiceAsync(int id)
        {
            try
            {
                var providerService = this.GetProviderServiceById(id);
                this.providerServiceRepository.Delete(providerService);
                await this.providerServiceRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ProviderService> UpdateProviderServiceAsync(ProviderService providerService)
        {
            try
            {
                var providerServiceToEdit = this.GetProviderServiceById(providerService.IdProviderService);
                providerServiceToEdit.Product = providerService.Product;
                providerServiceToEdit.Currency = providerService.Currency;
                providerServiceToEdit.Shipping = providerService.Shipping;
                providerServiceToEdit.Description = providerService.Description;
                providerServiceToEdit.ProductImage = providerService.ProductImage;
                providerServiceToEdit.IStatus= providerService.IStatus;
                providerServiceToEdit.TypeService = providerService.TypeService;
                providerServiceToEdit.IdServiceType = providerService.IdServiceType;

                var result = this.providerServiceRepository.Update(providerServiceToEdit);
                await this.providerServiceRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region"provideEval"
        public async Task<IEnumerable<ProviderEval>> GetProviderEvalAsync()
        {
            return await this.providerEvalRepository.All().ToListAsync();
        }
        public async Task<ProviderEval> CreateProviderEvalAsync(ProviderEvalDTO providerEval)
        {

            if (providerEval != null)
            {
                var newProviderEval = new ProviderEval
                {
                 Company=providerEval.Company,
                 Country=providerEval.Country,
                 Department=providerEval.Department,
                 Email=providerEval.Email,
                 Idcategory=providerEval.Idcategory,
                 Istatus=providerEval.Istatus,
                 LastName=providerEval.LastName,
                 Name=providerEval.Name,
                 Observation=providerEval.Observation,
                 Phone=providerEval.Phone 
                };


                var result = this.providerEvalRepository.Create(newProviderEval);
                await this.providerEvalRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<bool> DeleteProviderEvalAsync(int id)
        {
            try
            {
                var providerEval = this.GetProviderEvalById(id);
                this.providerEvalRepository.Delete(providerEval);
                await this.providerEvalRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<ProviderEval> UpdateProviderEvalAsync(ProviderEval providerEval)
        {
            try
            {
                var providerEvalToEdit = this.GetProviderEvalById(providerEval.IdEval);
                providerEval.Observation = providerEvalToEdit.Observation;
                providerEvalToEdit.LastName = providerEvalToEdit.LastName;
                providerEvalToEdit.Phone = providerEvalToEdit.Phone;
                providerEvalToEdit.Country = providerEvalToEdit.Country;
                providerEvalToEdit.Name = providerEvalToEdit.Name;
                providerEvalToEdit.Istatus = providerEvalToEdit.Istatus;
                providerEvalToEdit.Company = providerEvalToEdit.Company;

                var result = this.providerEvalRepository.Update(providerEvalToEdit);
                await this.providerEvalRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ProviderEval GetProviderEvalById(int id)
        {
            var providerEval = this.providerEvalRepository.Find(id);
            if (providerEval == null) throw new KeyNotFoundException("provider Eval not found");
            return providerEval;
        }
        #endregion












    }
}