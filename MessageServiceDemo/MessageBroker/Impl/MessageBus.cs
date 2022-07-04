using MessageBroker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBroker.Impl
{
    /// <summary>
    /// Message broker service
    /// </summary>
    public class MessageBus : IMessageBus
    {
        #region Singleton Implementation
        private static IMessageBus INSTANCE = null;

        public static IMessageBus getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new MessageBus();
            return INSTANCE;
        }
        private MessageBus()
        {

            
        }
        #endregion

        #region Private Members
        private readonly Dictionary<Type, List<WeakReference>> _observers = new Dictionary<Type, List<WeakReference>>(); 
        #endregion

        #region Extra info for debugging

        // Types of message that all subscribers are currently subscribed to.
        public List<Type> SubscribedTypes
        {
            get { return _observers.Keys.ToList(); }
        }

        public List<WeakReference> Subscribers
        {
            get { return GetSubscribers(); }
        }

        // All subscriber weak references currently subscribed
        private List<WeakReference> GetSubscribers()
        {
            List<WeakReference> subscribers = new List<WeakReference>();

            foreach (var subscriberType in SubscribedTypes)
            {
                subscribers.AddRange(_observers[subscriberType]);
            }

            return subscribers;
        }

        #endregion Extra info for debugging

        #region Interface Implementation
        public void Publish<T>(T message) where T : IMessage
        {
            try
            {
                if (message == null) throw new ArgumentNullException(nameof(message));

                var subscriberType = typeof(ISubscribe<>).MakeGenericType(typeof(T)); // --> ISubscribe<T>

                if (_observers.ContainsKey(subscriberType))
                {
                    List<WeakReference> subscriberRefs = _observers[subscriberType];
                    List<WeakReference> deadSubscriberRefs = new List<WeakReference>();

                    foreach (var subscriberRef in subscriberRefs)
                    {
                        if (subscriberRef.IsAlive)
                        {
                            var subscriber = subscriberRef.Target as ISubscribe<T>;
                            subscriber?.OnMessageReceived(message);
                        }
                        else
                            deadSubscriberRefs.Add(subscriberRef); // Remove this reference
                    }

                    subscriberRefs.RemoveAll(s => deadSubscriberRefs.Contains(s));
                    if (subscriberRefs.Count == 0)
                        _observers.Remove(subscriberType);
                }
            }
            catch
            {
                throw;
            }
        }

        public int Subscribe(object subscriber, bool reSubscribable = false)
        {
            if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));

            WeakReference subscriberRef = new WeakReference(subscriber);
            var subscriberTypes = GetSubscriberTypes(subscriber);

            foreach (var subscriberType in subscriberTypes)
            {
                if (_observers.ContainsKey(subscriberType))
                {
                    _observers[subscriberType].RemoveAll(s => !s.IsAlive);

                    if (!_observers[subscriberType].Any(s => s.Target == subscriberRef.Target) || reSubscribable)
                        _observers[subscriberType].Add(subscriberRef);
                }
                else
                    _observers.Add(subscriberType, new List<WeakReference> { subscriberRef });
            }

            return subscriberTypes.ToList().Count;
        }

        public int UnSubscribe(object subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));

            var subscriberRef = new WeakReference(subscriber);
            var subscriberTypes = GetSubscriberTypes(subscriber);
            var emptyKeys = new List<Type>();

            int unSubscribedTypeCount = 0;

            foreach (var subscriberType in subscriberTypes)
            {
                if (_observers.ContainsKey(subscriberType))
                {
                    List<WeakReference> subscriberRefs = _observers[subscriberType];
                    unSubscribedTypeCount += subscriberRefs.RemoveAll(s => s.Target == subscriber);

                    if (subscriberRefs.Count == 0)
                        emptyKeys.Add(subscriberType);
                }
            }

            foreach (var key in emptyKeys)
                _observers.Remove(key);

            return unSubscribedTypeCount;
        }

        public bool UnSubscribeTo<T>() where T : IMessage
        {
            var subscriberType = typeof(ISubscribe<>).MakeGenericType(typeof(T)); // --> ISubscribe<T>
            if (_observers.ContainsKey(subscriberType))
                return _observers.Remove(subscriberType);
            else
                throw new KeyNotFoundException(subscriberType.ToString());
        }
        #endregion

        #region Private methods
        private IEnumerable<Type> GetSubscriberTypes(object subscriber)
        {
            return subscriber
                .GetType()
                .GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubscribe<>));
        } 
        #endregion
    }
}
