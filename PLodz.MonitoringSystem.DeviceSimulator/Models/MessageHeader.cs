namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public class MessageHeader
    {
        public string organization_id { get; set; }
        public string entity_uuid { get; set; }
        public string message_uuid { get; set; }
        public string message_type { get; set; }
        public int publish_time { get; set; }
    }
}
