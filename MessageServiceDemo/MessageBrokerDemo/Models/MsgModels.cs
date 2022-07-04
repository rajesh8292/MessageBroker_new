using MessageBroker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Models
{
    public class EmployeeCreatedMessage : IMessage
    {
        public string Description { get; set; }

        public Employee Employee { get; set; }
    }

    public class EmployeeDeletedMessage : IMessage
    {
        public string Description { get; set; }

        public Employee Employee { get; set; }
    }
}
