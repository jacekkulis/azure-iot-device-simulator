using Microsoft.Azure.Devices.Client;
using System.Text;
using System.Threading.Tasks;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    public class IoTHubMessageSender : IMessageSender
    {
        private readonly DeviceClient _deviceClient;

        public IoTHubMessageSender(DeviceClient deviceClient)
        {
            _deviceClient = deviceClient;
        }

        public async Task SendMessage(MessageContext ctx, string messageType)
        {
            var customMessage = MessageFactory.CreateInstance(messageType);

            var msg = new Message(Encoding.UTF8.GetBytes(customMessage.Generate(ctx)));

            var props = customMessage.GetProperties();

            foreach (var prop in props)
            {
                msg.Properties.Add(prop);
            }

            msg.ContentType = customMessage.GetContentType();

            await _deviceClient.SendEventAsync(msg);
        }
    }
}