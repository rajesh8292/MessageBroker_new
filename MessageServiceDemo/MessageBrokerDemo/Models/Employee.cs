using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string? EmpName { get; set; }

        public long PhoneNumber { get; set; }
        public DateTime DateOfJoin { get; set; }

        public DateTime DateOfResignation { get;set; }
    }
}
