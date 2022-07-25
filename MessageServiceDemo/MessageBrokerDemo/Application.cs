using MessageBroker.Impl;
using MessageBroker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBrokerDemo.Pub;
using MessageBrokerDemo.Subscriber;
using MessageBrokerDemo.Impl;
using MessageBrokerDemo.Models;

namespace MessageBrokerDemo
{
    public class Application
    {
        public Application()
        {
            var empCreation = new EmpCreation();
        }
        public void Run()
        {
            //get singleton instance of message bus
            IMessageBus messageBus = MessageBus.getInstance();

            ILogger log = new ConsoleLogger();
            INotifier broker = new Notifier(log);


            Publisher publisher = new Publisher(messageBus);
            Subscriber1 subscriber1 = new Subscriber1(messageBus, broker);
            Subscriber2 subscriber2 = new Subscriber2(messageBus, broker);

            


            var task1 = Task.Factory.StartNew(() =>
            {
                publisher.CreateEmployee();
            });
            var task2 = Task.Factory.StartNew(() =>
            {
                publisher.DeleteEmployee();
            });

            Task.WaitAll(new Task[] { task1, task2 }); // <-- this will wait for both to complete

            
            Console.WriteLine("Start -UnSubscribing all events from sub1 -created msgs ");
            //subscriber1.UnSubscribe();
            subscriber1.UnSubscribeTo<EmployeeCreatedMessage>();

            Console.WriteLine("End -UnSubscribing all events from sub1-created msgs ");

            task1 = Task.Factory.StartNew(() =>
            {
                publisher.CreateEmployee();
            });
            task2 = Task.Factory.StartNew(() =>
            {
                publisher.DeleteEmployee();
            });
            Task.WaitAll(new Task[] { task1, task2 }); // <-- this will wait for both to complete

           


        }
    }
}
