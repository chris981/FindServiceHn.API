using System;
using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHn.Core.ServicesStatusManager
{
    //public class ServicesStatus : IServicesStatus
    //{
    //    private readonly IRepository<ServicesStatus> servicesstatusRepository;

    //    public ServicesStatusManager(IRepository<ServicesStatus> servicesstatusRepository)
    //    {
    //        this.servicesstatusRepository = servicesstatusRepository;

    //    }

    //    public async Task<IEnumerable<ServicesStatus>> GetAllAsync()
    //    {
    //        return await this.servicesstatusRepository.All().ToListAsync();
    //    }
    //}

}