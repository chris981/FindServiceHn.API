using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHN.Core.OrderHeaderManager
{
    public class OrderHeaderManager : IOrderHeaderManager
    {
        private IRepository<OrderHeader> orderHeaderRepository;

        public OrderHeaderManager(IRepository<OrderHeader> orderHeaderRepository)
        {
            this.orderHeaderRepository = orderHeaderRepository;
        }

        public async Task<IEnumerable<OrderHeader>> GetAllAsync()
        {
            return await this.orderHeaderRepository.All().ToListAsync();
        }

        public OrderHeader GetById(int id)
        {
            var orderHeader = this.orderHeaderRepository.Find(id);
            if (orderHeader == null) throw new KeyNotFoundException("Order detail not found");
            return orderHeader;
        }

        public async Task<bool> DeleteOrderHeaderAsync(int id)
        {
            try
            {
                var orderHeader = this.GetById(id);
                this.orderHeaderRepository.Delete(orderHeader);
                await this.orderHeaderRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<OrderHeader> UpdateOrderHeaderAsync(OrderHeader orderHeader)
        {
            try
            {
                var orderHeaderEdit = this.GetById(orderHeader.IdOrder);
                orderHeaderEdit.IdOrder = orderHeader.IdOrder;
                orderHeaderEdit.IdCustomer = orderHeader.IdCustomer;
                orderHeaderEdit.IdProvider = orderHeader.IdProvider;
                orderHeaderEdit.IdClientAddress = orderHeader.IdClientAddress;
                orderHeaderEdit.Description = orderHeader.Description;
                orderHeaderEdit.IdCategory = orderHeader.IdCategory;
                orderHeaderEdit.IdSubCategory = orderHeader.IdSubCategory;
                orderHeaderEdit.CreationDate = orderHeader.CreationDate;
                orderHeaderEdit.ExecutionDate = orderHeader.ExecutionDate;
                orderHeaderEdit.ClosingDate = orderHeader.ClosingDate;
                orderHeaderEdit.IdStatus = orderHeader.IdStatus;
                orderHeaderEdit.SatisfactionLevel = orderHeader.SatisfactionLevel;
                orderHeaderEdit.CustomerObservation = orderHeader.CustomerObservation;


                var result = this.orderHeaderRepository.Update(orderHeaderEdit);
                await this.orderHeaderRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OrderHeader> CreateOrderHeaderAsync(OrderHeaderDTO orderHeader)
        {
            if (orderHeader != null)
            {
                var newOrderHeader = new OrderHeader
                {
                    IdCustomer = orderHeader.IdCustomer,
                    IdProvider = orderHeader.IdProvider,
                    IdClientAddress = orderHeader.IdClientAddress,
                    Description = orderHeader.Description,
                    IdCategory = orderHeader.IdCategory,
                    IdSubCategory = orderHeader.IdSubCategory,
                    CreationDate = orderHeader.CreationDate,
                    ExecutionDate = orderHeader.ExecutionDate,
                    ClosingDate = orderHeader.ClosingDate,
                    IdStatus = orderHeader.IdStatus,
                    SatisfactionLevel= orderHeader.SatisfactionLevel,
                    CustomerObservation= orderHeader.CustomerObservation,

                };

                var result = this.orderHeaderRepository.Create(newOrderHeader);
                await this.orderHeaderRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
