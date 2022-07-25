using MessageBroker.Interfaces;
using MessageBrokerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Subscriber
{
    public class Subscriber2 : ISubscribe<EmployeeCreatedMessage>
    {
        private IMessageBus messageBus;
        private INotifier broker;
        public Subscriber2(IMessageBus messageBus, INotifier broker)
        {
            this.messageBus = messageBus;

            var subscription = this.messageBus.Subscribe(this);

            this.broker = broker;
        }

        public void OnMessageReceived(EmployeeCreatedMessage message)
        {
            broker.Notify("Sub2 Msg received : " + message.Description);
            //Console.WriteLine("Sub2 Msg received : " + message.Description);
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
