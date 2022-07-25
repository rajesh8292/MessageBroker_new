using MessageBroker.Interfaces;
using System;

namespace MessageBroker.Impl
{
    public class Notifier : INotifier
    {
        private ILogger logger;
        public Notifier(ILogger logger)
        {
            this.logger = logger;
        }

        public void Notify(string message)
        {
            logger.Log(message);

        }
    }
}
