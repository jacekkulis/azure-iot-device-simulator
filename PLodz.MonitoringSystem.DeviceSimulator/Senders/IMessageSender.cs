using System.Threading.Tasks;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    public interface IMessageSender
    {
        Task SendMessage(MessageContext ctx, string messageType);
    }
}