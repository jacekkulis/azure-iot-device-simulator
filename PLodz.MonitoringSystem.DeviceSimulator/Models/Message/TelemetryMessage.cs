using System;
using Newtonsoft.Json;

namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public class TelemetryMessage : MessageBase
    {
        public override string MessageType => "telemetry";

        public override string Generate(MessageContext ctx)
        {
            var msg = new TelemetryMessage()
            {
                Header = new MessageHeader()
                {
                    MessageUuid = ctx.Randomizer.NextGuid().ToString(),
                    MessageType = this.MessageType,
                    PublishTime = DateTime.Now
                },
                Body = new TelemetryData()
                {
                    Current = 2.2,
                    Voltage = 2.2
                }
            };

            return JsonConvert.SerializeObject(msg);
        }
    }

}
