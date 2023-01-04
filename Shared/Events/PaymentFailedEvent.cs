using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class PaymentFailedEvent : CorrelatedBy<Guid>
    {
        public PaymentFailedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public Guid CorrelationId { get; }
        public List<OrderItemMessage> OrderItems { get; set; }
        public string Message { get; set; }
    }
}
