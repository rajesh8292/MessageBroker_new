using MessageBrokerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Interfaces
{
    public interface IRepo
    {
        Employee CreateEmp(Employee employee);

        Employee Read(int id);

        Employee DeleteEmp(int id);

        int EmpCount { get; }
    }
}
