using MessageBroker.Interfaces;
using MessageBrokerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Subscriber
{
    public class Subscriber1 : ISubscribe<EmployeeCreatedMessage>, ISubscribe<EmployeeDeletedMessage>
    {
        private IMessageBus messageBus;

        public Subscriber1(IMessageBus messageBus)
        {
            this.messageBus = messageBus;

            var subscription = this.messageBus.Subscribe(this);
        }

        public void OnMessageReceived(EmployeeCreatedMessage message)
        {
            Console.WriteLine("Sub1 Msg received : " + message.Description);
            
        }

        public void OnMessageReceived(EmployeeDeletedMessage message)
        {
            Console.WriteLine("Sub1 Msg received : " + message.Description);
        }

        public int UnSubscribe()
        {
            return this.messageBus.UnSubscribe(this);
        }
        public bool UnSubscribeTo()
        {
            return this.messageBus.UnSubscribeTo<EmployeeDeletedMessage>();
        }
    }
}
