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

            Publisher publisher = new Publisher(messageBus);
            Subscriber1 subscriber1 = new Subscriber1(messageBus);
            Subscriber2 subscriber2 = new Subscriber2(messageBus);
            
            publisher.CreateEmployee();
            publisher.DeleteEmployee();
            
            //Task.Factory.StartNew(() =>
            //{
            //    publisher.CreateEmployee();
            //});
            //Task.Factory.StartNew(() =>
            //{
            //    publisher.DeleteEmployee();
            //});

            subscriber1.UnSubscribe();
            publisher.CreateEmployee();
            publisher.DeleteEmployee();
            //Task.Factory.StartNew(() =>
            //{
            //    publisher.CreateEmployee();
            //});
            //Task.Factory.StartNew(() =>
            //{
            //    publisher.DeleteEmployee();
            //});


        }
    }
}
