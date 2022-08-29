using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.DepartmentsManager
{
    public class DepartmentsManager : IDepartmentsManager
    {
        private readonly IRepository<Departments> DepartmentsRepository;

        public DepartmentsManager(IRepository<Departments> DepartmentsRepository)
        {
            this.DepartmentsRepository = DepartmentsRepository;
        }
        public async Task<IEnumerable<Departments>> GetAllAsync()
        {
            return await this.DepartmentsRepository.All().ToListAsync();
        }
        public Departments GetById(int id)
        {
            var department = this.DepartmentsRepository.Find(id);
            if (department == null) throw new KeyNotFoundException("not found");
            return department;
        }
        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            try
            {
                var department = this.GetById(id);
                this.DepartmentsRepository.Delete(department);
                await this.DepartmentsRepository.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<Departments> UpdateDepartmentAsync(Departments departments)
        {
            try
            {
                var DepartmentToEdit = this.GetById(departments.IdDepartment);
                DepartmentToEdit.IdDepartment = departments.IdDepartment;
                DepartmentToEdit.IdCountry = departments.IdCountry;
                DepartmentToEdit.Description = departments.Description;
                DepartmentToEdit.IdUserCreation =departments.IdUserCreation;
                DepartmentToEdit.Condition = departments.Condition;
                DepartmentToEdit.CreatedDate = departments.CreatedDate;

                var result = this.DepartmentsRepository.Update(DepartmentToEdit);
                await this.DepartmentsRepository.SaveChangesAsync();
                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<Departments> CreateDepartmentAsync(DepartmentsDTO departments)
        {
            if (departments != null)
            {
                var newDepartment = new Departments
                {
                    IdDepartment = departments.IdDepartment,
                    IdCountry = departments.IdCountry,
                    Description = departments.Description,
                    CreatedDate = departments.CreatedDate,
                    IdUserCreation = departments.IdUserCreation,
                    Condition = departments.Condition,
                };

                var result = this.DepartmentsRepository.Create(newDepartment);
                await this.DepartmentsRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
