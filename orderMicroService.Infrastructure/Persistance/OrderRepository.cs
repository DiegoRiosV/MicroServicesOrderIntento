using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using orderMicroService.Domain.Entities;
using orderMicroService.Domain.Ports;
using orderMicroService.Infrastructure.Connection;

namespace orderMicroService.Infrastructure.Persistance
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public OrderRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            await using var connection = _dbConnectionFactory.CreateConnection();
            const string query = "";//"SELECT * FROM fn_get_active_orders()";
            return await connection.QueryAsync<Order>(query);
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            await using var connection = _dbConnectionFactory.CreateConnection();
            const string query = "";// "SELECT * FROM fn_get_order_by_id(@id)";//cambiar
            return await connection.QuerySingleOrDefaultAsync<Order>(query, new { id });
        }

        public async Task<bool> CreateAsync(Order order, int userId)
        {
            await using var connection = _dbConnectionFactory.CreateConnection();
            const string query = "";//"SELECT fn_insert_service(@name, @type, @price, @description, @created_by_user_id)";
            var parameters = new
            {
                total = order.Total,
                created_by_user_id = userId
            };
            var newId = await connection.ExecuteScalarAsync<int>(query, parameters);
            order.Id = newId;
            return newId > 0;
        }

        public async Task<bool> UpdateAsync(Order order, int userId)
        {
            await using var connection = _dbConnectionFactory.CreateConnection();
            const string query = "";//"SELECT fn_update_service(@id, @name, @type, @price, @description, @modified_by_user_id)";
            var parameters = new
            {
                id = order.Id,
                total = order.Total,
                owner_id = order.Owner_id,
                vehicle_id = order.Vehicle_id,
                user_id = order.User_Account_id,
                modified_by_user_id = userId
            };
            return await connection.ExecuteScalarAsync<bool>(query, parameters);
        }

        public async Task<bool> DeleteByIdAsync(int id, int userId)
        {
            await using var connection = _dbConnectionFactory.CreateConnection();
            const string query = "";//"SELECT fn_soft_delete_service(@id, @modified_by_user_id)";
            var parameters = new
            {
                id,
                modified_by_user_id = userId
            };
            return await connection.ExecuteScalarAsync<bool>(query, parameters);
        }
    }
}