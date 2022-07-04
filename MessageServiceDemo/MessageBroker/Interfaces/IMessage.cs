using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBroker.Interfaces
{
    public interface IMessage
    {
        string Description { get; }
    }
}
