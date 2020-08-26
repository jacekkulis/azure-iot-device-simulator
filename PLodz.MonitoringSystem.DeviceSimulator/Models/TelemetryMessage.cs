using Newtonsoft.Json;

namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public class TelemetryMessage : MessageBase
    {
        public override string MessageType => "telemetry";

        public override string Generate(MessageContext ctx, bool keepState = false)
        {
            var msg = new TelemetryMessage()
            {
                Header = new MessageHeader()
                {
                    organization_id = ctx.CreateGuid(),
                    entity_uuid = ctx.AssetId,
                    message_uuid = ctx.CreateGuid(),
                    message_type = this.MessageType,
                    publish_time = ctx.EpochTimestamp()
                },
                Body = new TelemetryData()
                {
                    a = 2.2,
                    v = 2.2
                }
            };

            ctx.Messages.Add(msg);
            return JsonConvert.SerializeObject(msg);
        }
    }

}
