using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandGEM.Services
{
    public class Messenger
    {
        private static Messenger _instance;
        private readonly Dictionary<Type, List<Action<object>>> _subscriptions
            = new Dictionary<Type, List<Action<object>>>();

        public static Messenger Instance => _instance ??= new Messenger();

        public void Subscribe<TMessage>(Action<TMessage> action)
        {
            if (!_subscriptions.ContainsKey(typeof(TMessage)))
            {
                _subscriptions[typeof(TMessage)] = new List<Action<object>>();
            }
            _subscriptions[typeof(TMessage)].Add(o => action((TMessage)o));
        }

        public void Send<TMessage>(TMessage message)
        {
            if (_subscriptions.ContainsKey(typeof(TMessage)))
            {
                foreach (var action in _subscriptions[typeof(TMessage)])
                {
                    action(message);
                }
            }
        }
    }
}
