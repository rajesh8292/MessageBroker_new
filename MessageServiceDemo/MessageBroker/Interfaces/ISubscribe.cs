using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBroker.Interfaces
{
    public interface ISubscribe<T> where T : IMessage
    {
        /// <summary>
        /// message received  on each publish
        /// </summary>
        /// <param name="message"></param>
        void OnMessageReceived(T message);
    }
}
