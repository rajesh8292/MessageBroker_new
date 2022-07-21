using MessageBroker.Interfaces;
using MessageBrokerDemo.Models;

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
        public bool UnSubscribeTo<T>() where T : IMessage
        {
            
            //T = typeof(type1);
            return this.messageBus.UnSubscribeTo<T>();
        }
    }
}
