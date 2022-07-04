using MessageBrokerDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Impl
{
    public class Factory : IFactory
    {
        public object Get(string key)
        {
            IRepo repo = null;
            if (key == "InMemory")
            {
                repo = InMemoryRepo.getInstance();

            }
            
            return repo;
        }
        public object Get(string key, object repo)
        {
            throw new NotImplementedException();
        }


    }

    public class DirectoryFactory : IFactory
    {
        public object Get(string key)
        {

            throw new NotImplementedException();

        }

        public object Get(string key, object repo)
        {
            IDirectory directory = null;
            
            if (key == "Basic")
            {
                directory = new EmployeeDirectory((IRepo)repo);
            }                      
            return directory;
        }
    }
}
