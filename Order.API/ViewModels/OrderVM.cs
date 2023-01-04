using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.ViewModels
{
    public class OrderVM
    {
        public int BuyerId { get; set; }
        public List<OrderItemVM> OrderItems { get; set; }
    }
}
