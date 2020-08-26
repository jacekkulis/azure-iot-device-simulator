using System;
using System.Collections.Generic;
using Microsoft.Azure.Devices.Client;
using System.Text;
using System.Threading.Tasks;
using PLodz.MonitoringSystem.DeviceSimulator.Models;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    public class IoTHubMessageSender : IMessageSender
    {
        const string ApplicationJsonContentType = "application/json";
        const string Utf8Encoding = "utf-8";

        private readonly DeviceClient _deviceClient;

        public IoTHubMessageSender(DeviceClient deviceClient)
        {
            _deviceClient = deviceClient;
        }

        public async Task SendMessage(MessageContext ctx, string messageType)
        {
            var customMessage = MessageGenerator.CreateInstance(messageType);

            var msg = BuildMessage(customMessage);

            await _deviceClient.SendEventAsync(msg);
        }

        public Message BuildMessage(IMessage message)
        {
            var messageBytes = message.GetBytes();

            var msg = new Message(messageBytes)
            {
                CorrelationId = Guid.NewGuid().ToString(),
                ContentEncoding = Utf8Encoding,
                ContentType = message.GetContentType()
            };

            SetMessageProperties(msg, message.GetProperties());

            return msg;
        }

        public void SetMessageProperties(Message message, Dictionary<string, string> properties)
        {
            foreach (var prop in properties)
            {
                message.Properties.Add(prop);
            }
        }
    }
}