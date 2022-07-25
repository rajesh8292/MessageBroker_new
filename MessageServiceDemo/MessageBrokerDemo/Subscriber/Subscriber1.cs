using MessageBroker.Interfaces;
using MessageBrokerDemo.Models;

namespace MessageBrokerDemo.Subscriber
{
    public class Subscriber1 : ISubscribe<EmployeeCreatedMessage>, ISubscribe<EmployeeDeletedMessage>
    {
        private IMessageBus messageBus;
        private INotifier broker;
        public Subscriber1(IMessageBus messageBus,INotifier broker)
        {
            this.messageBus = messageBus;

            var subscription = this.messageBus.Subscribe(this);
            this.broker = broker;
        }

        public void OnMessageReceived(EmployeeCreatedMessage message)
        {
            broker.Notify("Sub1 Msg received : " + message.Description);
            
            
        }

        public void OnMessageReceived(EmployeeDeletedMessage message)
        {
            broker.Notify("Sub1 Msg received : " + message.Description);
            // Console.WriteLine("Sub1 Msg received : " + message.Description);
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
