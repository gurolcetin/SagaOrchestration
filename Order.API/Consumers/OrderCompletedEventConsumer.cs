using MassTransit;
using Order.API.Models.Contexts;
using Order.API.Models.Enums;
using Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Consumers
{
    public class OrderCompletedEventConsumer : IConsumer<OrderCompletedEvent>
    {
        readonly ApplicationDbContext _applicationDbContext;
        public OrderCompletedEventConsumer(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task Consume(ConsumeContext<OrderCompletedEvent> context)
        {
            Models.Order order = await _applicationDbContext.Orders.FindAsync(context.Message.OrderId);
            if (order != null)
            {
                order.OrderStatus = OrderStatus.Completed;
                await _applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
