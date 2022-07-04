using MessageBrokerDemo.Interfaces;
using MessageBrokerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Impl
{
    public class EmpCreation
    {
        #region Private members
        IRepo repo;
        IFactory factory;
        IDirectory directory;
        Random rnd = new Random();
        #endregion

        #region Constructor
        public EmpCreation()
        {
            factory = new Factory();
            SetUpFactory();
            SetupDirectory();
            AddEmp();
        }
        #endregion

        #region Private Methods
        private void SetUpFactory()
        {
            repo = (IRepo)factory.Get("InMemory");
        }
        private void SetupDirectory()
        {
            factory = new DirectoryFactory();
            directory = (IDirectory)factory.Get("Basic", repo);

        }
        private void AddEmp()
        {

            List<string> names = new List<string>() { "rajesh", "siddharth", "varun", "kiran", "ashok", "gaurav", "shiva", "Saketh", "Manju", "Mintu", "Krishna" };
            foreach (var item in names)
            {
                Employee emp = new Employee()
                {
                    EmpName = item,
                    PhoneNumber = 1234567896,
                    DateOfJoin = GetDate()
                };
                directory.Add(emp);
            }

        }

        private DateTime GetDate()
        {
            DateTime dt = new DateTime(2022, 7, 3);
            dt = dt.AddDays(-rnd.Next(2, 30));
            return dt;
        }
        #endregion


    }
}
