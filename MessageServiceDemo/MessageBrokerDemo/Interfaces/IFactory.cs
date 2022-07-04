using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Interfaces
{
    public interface IFactory
    {
        object Get(string key);
        object Get(string key, object repo);

    }
}
