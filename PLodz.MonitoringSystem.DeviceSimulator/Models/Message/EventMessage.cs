using System;
using Newtonsoft.Json;

namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public class EventMessage : MessageBase
    {
        public override string MessageType => "event";

        public override string Generate(MessageContext ctx)
        {
            var msg = new EventMessage()
            {
                Header = new MessageHeader()
                {
                    MessageUuid = ctx.Randomizer.NextGuid().ToString(),
                    MessageType = this.MessageType,
                    PublishTime = DateTime.Now
                },
                Body = new EventData()
                {
                    EventLevel = "highest"
                }
            };

            return JsonConvert.SerializeObject(msg);
        }
    }

}
