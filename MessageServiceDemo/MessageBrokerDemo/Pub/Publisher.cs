using MessageBroker.Interfaces;
using MessageBrokerDemo.Impl;
using MessageBrokerDemo.Interfaces;
using MessageBrokerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Pub
{
    public class Publisher
    {
        #region Private Members
        Random rnd = new Random();
        IRepo repo;        
        private IMessageBus messageBus;       
        
        #endregion

        #region Constructor
        public Publisher(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
            repo = InMemoryRepo.getInstance();
        }
        #endregion

        #region Public Methods
        public async void CreateEmployee()
        {
            Employee emp = repo.Read(rnd.Next(1, 10));
            Console.WriteLine("--------------");
            this.messageBus.Publish<EmployeeCreatedMessage>(new EmployeeCreatedMessage
            {
                Employee = emp,
                Description = String.Format("[Add Emp] A employee with name {0} has been created.",emp.EmpName),
            });

            emp = repo.Read(rnd.Next(1, 10));
            Console.WriteLine("--------------");
            this.messageBus.Publish<EmployeeCreatedMessage>(new EmployeeCreatedMessage
            {
                Employee = emp,
                Description = String.Format("[Add Emp] A employee with name {0} has been created.", emp.EmpName),
            });
        }

        public void DeleteEmployee()
        {
            var emp = repo.Read(repo.EmpCount-1);
            if (emp == null) return;
            Console.WriteLine("--------------");
            this.messageBus.Publish<EmployeeDeletedMessage>(new EmployeeDeletedMessage
            {
                Description = String.Format("[Delete Emp] A employee with name {0} has been deleted.", emp.EmpName),
                Employee = emp

            });
        } 
        #endregion
    }
}
