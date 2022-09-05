using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.CustomersManager
{
    public class CustomersManager : ICustomersManager
    {
        private readonly IRepository<Customers> CustomersRepository;

        public CustomersManager(IRepository<Customers> CustomerRepository)
        {
            this.CustomersRepository = CustomerRepository;
        }
        public async Task<IEnumerable<Customers>> getAllAsync()
        {
            return await this.CustomersRepository.All().ToListAsync();
        }

        public Customers GetById(int id)
        {
            var customers = this.CustomersRepository.Find(id);
            if (customers == null) throw new KeyNotFoundException("Not Found");
            return customers;
        }
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var customer = this.GetById(id);
                this.CustomersRepository.Delete(customer);
                await this.CustomersRepository.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<Customers> UpdateCustomerAsync(Customers customers)
        {
            try
            {
                var customerToEdit = this.GetById(customers.IdCustomer);
                customerToEdit.IdCustomer = customers.IdCustomer;
                customerToEdit.emailpassword = customers.emailpassword;
                customerToEdit.Rtn = customers.Rtn;
                customerToEdit.Identificationcard = customers.Identificationcard;
                customerToEdit.Name = customers.Name;
                customerToEdit.LastName = customers.LastName;
                customerToEdit.IdCustomerAddress = customers.IdCustomerAddress;
                customerToEdit.Country = customers.Country;
                customerToEdit.Department = customers.Department;
                customerToEdit.Municipality = customers.Municipality;
                customerToEdit.BirthDate = customers.BirthDate;
                customerToEdit.Phone = customers.Phone;
                customerToEdit.Status = customers.Status;
                customerToEdit.ProfilePicture = customers.ProfilePicture;
                customerToEdit.MainProfile = customers.MainProfile;
                customerToEdit.KeyValidation = customers.KeyValidation;
                customerToEdit.UserType = customers.UserType;
                customerToEdit.RegistrationDate = customers.RegistrationDate;

                var result = this.CustomersRepository.Update(customerToEdit);
                await this.CustomersRepository.SaveChangesAsync();
                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<Customers> CreateCustomerAsync(CustomersDTO customers)
        {
            if (customers != null)
            {
                var newCustomer = new Customers
                {
                    emailpassword = customers.emailpassword,
                    Rtn = customers.Rtn,
                    Identificationcard = customers.Identificationcard,
                    Name = customers.Name,
                    LastName = customers.LastName,
                    IdCustomerAddress = customers.IdCustomerAddress,
                    Country = customers.Country,
                    Department = customers.Department,
                    Municipality = customers.Municipality,
                    BirthDate = customers.BirthDate,
                    Phone = customers.Phone,
                    Status = customers.Status,
                    ProfilePicture = customers.ProfilePicture,
                    MainProfile = customers.MainProfile,
                    KeyValidation = customers.KeyValidation,
                    UserType = customers.UserType,
                    RegistrationDate = customers.RegistrationDate,
                };

                var result = this.CustomersRepository.Create(newCustomer);
                await this.CustomersRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
