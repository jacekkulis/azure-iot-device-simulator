using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    public class MessagePropagator
    {
        private readonly Dictionary<Guid, IMessageSender> _senders;

        public MessagePropagator()
        {
            _senders = new Dictionary<Guid, IMessageSender>();
        }

        public Guid RegisterMessageSender<T>(params object[] arg) where T : IMessageSender
        {
            var id = Guid.NewGuid();
            _senders.Add(id, (T)Activator.CreateInstance(typeof(T), arg));
            return id;
        }

        public void UnregisterMessageSender(Guid id)
        {
            try
            {
                _senders.Remove(id);
            }
            catch (Exception)
            {

            }
        }

        public async Task SendMessage(List<MessageContext> contexts, string messageType)
        {
            for (var i = 0; i < _senders.Count; i++)
            {
                await _senders.ElementAt(i).Value.SendMessage(contexts[i], messageType);
            }
        }

        //public async Task SendMessage<T>(MessageContext ctx) where T : IMessage
        //{
        //    foreach (var sender in _senders)
        //    {
        //        await sender.Value.SendMessage<T>(ctx);
        //    }
        //}
    }
}
