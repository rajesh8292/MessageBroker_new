using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBroker.Interfaces
{
    public interface ILogger
    {
        void Log(string message);
    }
    public interface INotifier
    {
        void Notify(string message);

    }
}
