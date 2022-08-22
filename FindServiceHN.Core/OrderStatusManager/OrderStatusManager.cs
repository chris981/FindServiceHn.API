using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.OrderStatusManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderStatusManager
{
	public class OrderStatusManager : IOrderStatusManager
	{
        private IRepository<OrderStatus> orderStatusRepository;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public OrderStatusManager(
            IRepository<OrderStatus> orderStatusRepository,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            this.orderStatusRepository = orderStatusRepository;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }



        public IEnumerable<OrderStatus> GetAll()
        {
            return this.orderStatusRepository.All();
        }

        public OrderStatus GetById(int id)
        {
            var orderStatus = this.orderStatusRepository.Find(id);
            if (orderStatus == null) throw new KeyNotFoundException("Order satisfaction not found");
            return orderStatus;
        }

        public async Task<bool> DeleteOrderStatusAsync(int id)
        {
            try
            {
                var orderStatus = this.GetById(id);
                this.orderStatusRepository.Delete(orderStatus);
                await this.orderStatusRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<OrderStatus> UpdateOrderStatusAsync(OrderStatus orderStatus)
        {
            try
            {
                var orderStatusToEdit = this.GetById(orderStatus.IdStatusOrder);
                orderStatusToEdit.IdStatus = orderStatus.IdStatus;
                orderStatusToEdit.Description = orderStatus.Description;

                var result = this.orderStatusRepository.Update(orderStatusToEdit);
                await this.orderStatusRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OrderStatus> CreateOrderStatusAsync(OrderStatusDTO orderStatus)
        {
            if (orderStatus != null)
            {
                var newOrderStatus = new OrderStatus
                {
                    IdStatus = orderStatus.IdStatus,
                    Description = orderStatus.Description,

                };

                var result = this.orderStatusRepository.Create(newOrderStatus);
                await this.orderStatusRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
