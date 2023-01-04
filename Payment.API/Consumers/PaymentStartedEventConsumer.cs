using MassTransit;
using Shared;
using Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Consumers
{
    public class PaymentStartedEventConsumer : IConsumer<PaymentStartedEvent>
    {
        readonly ISendEndpointProvider _sendEndpointProvider;
        readonly IPublishEndpoint _publishEndpoint;
        public PaymentStartedEventConsumer(ISendEndpointProvider sendEndpointProvider,
            IPublishEndpoint publishEndpoint)
        {
            this._sendEndpointProvider = sendEndpointProvider;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<PaymentStartedEvent> context)
        {
            ISendEndpoint sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettings.StateMachine}"));
            if (context.Message.TotalPrice <= 100)
                await sendEndpoint.Send(new PaymentCompletedEvent(context.Message.CorrelationId));
            else
                await sendEndpoint.Send(new PaymentFailedEvent(context.Message.CorrelationId)
                {
                    Message = "Bakiye yetersiz!",
                    OrderItems = context.Message.OrderItems
                });
        }
    }
}
