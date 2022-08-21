using FindServiceHn.Database.Models;
using FindServiceHn.Database.Repositories;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.Models;
using FindServiceHN.Core.UserManager;
using Microsoft.Extensions.Options;

namespace FindServiceHN.Core.OrderSatisfactionManager
{
	public class OrderSatisfactionManager : IOrderSatisfactionManager
	{
        private IRepository<OrderSatisfaction> orderSatisfactionRepository;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public OrderSatisfactionManager(
            IRepository<OrderSatisfaction> orderSatisfactionRepository,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            this.orderSatisfactionRepository = orderSatisfactionRepository;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }



        public IEnumerable<OrderSatisfaction> GetAll()
        {
            return this.orderSatisfactionRepository.All();
        }

        public OrderSatisfaction GetById(int id)
        {
            var orderSatisfaction = this.orderSatisfactionRepository.Find(id);
            if (orderSatisfaction == null) throw new KeyNotFoundException("Order satisfaction not found");
            return orderSatisfaction;
        }

        public async Task<bool> DeleteOrderSatisfactionAsync(int id)
        {
            try
            {
                var orderSatisfaction = this.GetById(id);
                this.orderSatisfactionRepository.Delete(orderSatisfaction);
                await this.orderSatisfactionRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<OrderSatisfaction> UpdateOrderSatisfactionAsync(OrderSatisfaction orderSatisfaction)
        {
            try
            {
                var orderSatisfactionToEdit = this.GetById(orderSatisfaction.IdSatisfaction);
                orderSatisfactionToEdit.Valorization = orderSatisfaction.Valorization;
                orderSatisfactionToEdit.Description = orderSatisfaction.Description;
                
                var result = this.orderSatisfactionRepository.Update(orderSatisfactionToEdit);
                await this.orderSatisfactionRepository.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OrderSatisfaction> CreateOrderSatisfactionAsync(OrderSatisfactionDTO orderSatisfaction)
        {
            if (orderSatisfaction != null)
            {
                var newOrderSatisfaction = new OrderSatisfaction
                {
                    Valorization = orderSatisfaction.Valorization,
                    Description = orderSatisfaction.Description,
                    
                };

                var result = this.orderSatisfactionRepository.Create(newOrderSatisfaction);
                await this.orderSatisfactionRepository.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
