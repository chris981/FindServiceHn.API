using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CustomerAddressManager
{
    public class CustomerAddressManager : ICustomerAddressManager
    {
        private readonly IRepository<CustomerAddress> CustomerAddressRepository;

        public CustomerAddressManager(IRepository<CustomerAddress> CustomerAddressRepository)
        {
            this.CustomerAddressRepository = CustomerAddressRepository;  
        }
        public async Task<IEnumerable<CustomerAddress>> GetAllAsync()
        {
            return await this.CustomerAddressRepository.All().ToListAsync();
        }
        public CustomerAddress GetById(int id)
        {
            var customerAddress = this.CustomerAddressRepository.Find(id);
            if (customerAddress == null) throw new KeyNotFoundException("not found");
            return customerAddress;
        }
        public async Task<bool> DeleteCustomerAddressAsync(int id)
        {
            try
            {
                var cAddress = this.GetById(id);
                this.CustomerAddressRepository.Delete(cAddress);
                await this.CustomerAddressRepository.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<CustomerAddress> UpdateCustomerAddressAsync(CustomerAddress customerAddress)
        {
            try
            {
                var customerAddressToEdit = this.GetById(customerAddress.IdCustomerAddress);
                customerAddressToEdit.IdCustomerAddress = customerAddress.IdCustomerAddress;
                customerAddressToEdit.IdCustomer = customerAddress.IdCustomer;
                customerAddressToEdit.IdCountry = customerAddress.IdCountry;
                customerAddressToEdit.IdDeparment = customerAddress.IdDeparment;
                customerAddressToEdit.IdMunicipality = customerAddress.IdMunicipality;
                customerAddressToEdit.Direction = customerAddress.Direction;
                customerAddressToEdit.Observations = customerAddress.Observations;
                customerAddressToEdit.idStatus = customerAddress.idStatus;

                var result = this.CustomerAddressRepository.Update(customerAddressToEdit);
                await this.CustomerAddressRepository.SaveChangesAsync();
                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<CustomerAddress> CreateCustomerAddressAsync(CustomerAddressDTO customerAddress)
        {
            if (customerAddress != null)
            {
                var newCustomerAddress = new CustomerAddress
                {
                    IdCustomerAddress = customerAddress.IdCustomerAddress,
                    IdCustomer = customerAddress.IdCustomer,
                    IdCountry = customerAddress.IdCountry,
                    IdDeparment = customerAddress.IdDeparment,
                    IdMunicipality=customerAddress.IdMunicipality,
                    Direction = customerAddress.Direction,
                    Observations = customerAddress.Observations,
                    idStatus = customerAddress.idStatus,
                };

                var result = this.CustomerAddressRepository.Create(newCustomerAddress);
                await this.CustomerAddressRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
