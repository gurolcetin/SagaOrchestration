using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class RabbitMQSettings
    {
        public const string StateMachine = "state-machine-queue";
        public const string Stock_OrderCreatedEventQueue = "stock-order-created-queue";
        public const string Payment_StartedEventQueue = "payment-started-queue";
        public const string Order_OrderCompletedEventQueue = "order-order-completed-queue";
        public const string Order_OrderFailedEventQueue = "order-order-failed-queue";
        public const string Stock_RollbackMessageQueue = "stock-roolback-queue";
    }
}
