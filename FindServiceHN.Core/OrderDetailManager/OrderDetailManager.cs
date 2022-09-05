using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.Models;
using FindServiceHN.Core.UserManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FindServiceHN.Core.OrderDetailManager
{
	public class OrderDetailManager : IOrderDetailManager
	{
        private IRepository<OrderDetail> orderDetailRepository;

        public OrderDetailManager(
            IRepository<OrderDetail> orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await this.orderDetailRepository.All().ToListAsync();
        }

        public OrderDetail GetById(int id)
        {
            var orderDetail = this.orderDetailRepository.Find(id);
            if (orderDetail == null) throw new KeyNotFoundException("Order detail not found");
            return orderDetail;
        }

        public async Task<bool> DeleteOrderDetailAsync(int id)
        {
            try
            {
                var orderDetail = this.GetById(id);
                this.orderDetailRepository.Delete(orderDetail);
                await this.orderDetailRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            try
            {
                var orderDetailToEdit = this.GetById(orderDetail.IdOrder);
                orderDetailToEdit.IdCustomer = orderDetail.IdCustomer;
                orderDetailToEdit.IdProvider = orderDetail.IdProvider;
                orderDetailToEdit.Line = orderDetail.Line;
                orderDetailToEdit.IdProduct = orderDetail.IdProduct;
                orderDetailToEdit.Price = orderDetail.Price;                
                orderDetailToEdit.Amount = orderDetail.Amount;
                orderDetailToEdit.IdStatus = orderDetail.IdStatus;               

                var result = this.orderDetailRepository.Update(orderDetailToEdit);
                await this.orderDetailRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OrderDetail> CreateOrderDetailAsync (OrderDetailDTO orderDetail)
        {
            if (orderDetail != null)
            {
                var newOrderDetail = new OrderDetail
                {
                    IdCustomer = orderDetail.IdCustomer,
                    IdProvider = orderDetail.IdProvider,
                    Line = orderDetail.Line,
                    IdProduct = orderDetail.IdProduct,
                    Price = orderDetail.Price,
                    Amount = orderDetail.Amount,
                    IdStatus = orderDetail.IdStatus,
                
                };
              
                var result = this.orderDetailRepository.Create(newOrderDetail);
                await this.orderDetailRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
