using orderMicroService.Domain.Entities;
using orderMicroService.Domain.Ports;

namespace orderMicroService.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository orderRepository)
        {
            _repository = orderRepository;
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> Create(Order service, int userId)
        {
            return await _repository.CreateAsync(service, userId);
        }

        public async Task<bool> Update(Order service, int userId)
        {
            return await _repository.UpdateAsync(service, userId);
        }

        public async Task<bool> DeleteById(int id, int userId)
        {
            return await _repository.DeleteByIdAsync(id, userId);
        }
    }
}