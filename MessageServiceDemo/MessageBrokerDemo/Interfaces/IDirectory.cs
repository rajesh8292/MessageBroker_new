using MessageBrokerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Interfaces
{
    public interface IDirectory
    {
        Employee Add(Employee employee);
        Employee Find(Employee employee);
        Employee Delete(int id);
    }
}
