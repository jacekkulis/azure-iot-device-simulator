using Newtonsoft.Json;

namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public class EventMessage : MessageBase
    {
        public override string MessageType => "event";

        public override string Generate(MessageContext ctx, bool keepState = false)
        {
            var msg = new EventMessage()
            {
                Header = new MessageHeader()
                {
                    organization_id = ctx.CreateGuid(),
                    entity_uuid = ctx.AssetId,
                    message_uuid = ctx.CreateGuid(),
                    message_type = this.MessageType,
                    publish_time = ctx.EpochTimestamp()
                },
                Body = new EventData()
                {
                    EventLevel = "highest"
                }
            };

            ctx.Messages.Add(msg);
            return JsonConvert.SerializeObject(msg);
        }
    }

}
