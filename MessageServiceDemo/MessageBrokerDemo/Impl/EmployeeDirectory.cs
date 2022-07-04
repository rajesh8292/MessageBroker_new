using MessageBrokerDemo.Interfaces;
using MessageBrokerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Impl
{
    public class EmployeeDirectory : IDirectory
    {
        IRepo repository;
        public EmployeeDirectory(IRepo repo)
        {
            repository = repo;
        }
        public Employee Add(Employee employee)
        {
            employee = repository.CreateEmp(employee);
            return employee;
        }

       

        public Employee Delete(int id)
        {
            Employee emp = repository.DeleteEmp(id);
            return emp;
        }

        public Employee Find(Employee employee)
        {
            Employee emp = repository.Read(employee.EmployeeID);
            return emp;
        }

       
    }
}
