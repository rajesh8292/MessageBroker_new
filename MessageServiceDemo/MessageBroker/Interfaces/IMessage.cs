using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBroker.Interfaces
{
    public interface IMessage
    {
        /// <summary>
        /// Message to send via msg broker
        /// </summary>
        string Description { get; }
    }
}
