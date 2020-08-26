using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using PLodz.MonitoringSystem.DeviceSimulator.Models;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    public interface IMessageSender
    {
        Task SendMessage(MessageContext ctx, string messageType);

        void SetMessageProperties(Message message, Dictionary<string, string> properties);

        Message BuildMessage(IMessage message);
    }
}