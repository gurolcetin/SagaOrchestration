using Order.API.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
