using System;

namespace orderMicroService.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Owner_id { get; set; }
        public int User_Account_id { get; set; }
        public decimal Total { get; set; }
        public int Vehicle_id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}