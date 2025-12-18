using System.Collections.Generic;
using System.Threading.Tasks;
using orderMicroService.Domain.Entities;  

namespace orderMicroService.Domain.Ports
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<bool> CreateAsync(Order order, int userId);
        Task<bool> UpdateAsync(Order order, int userId);
        Task<bool> DeleteByIdAsync(int id, int userId);
    }
}