using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBroker.Interfaces
{
    public interface IMessageBus
    {
        void Publish<T>(T message) where T : IMessage;

        // Returns number of messages that this subscriber wants to listen to.
        int Subscribe(object subscriber, bool reSubscribable = false);

        // Returns number of messages that this subscriber has topped listening to.
        int UnSubscribe(object subscriber);

        // Return if successfully un-subscribed all subscribers from specified kind of message T.
        bool UnSubscribeTo<T>() where T : IMessage;
    }
}
