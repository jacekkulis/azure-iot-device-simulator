using System;
using Newtonsoft.Json;

namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public class MessageHeader
    {
        [JsonProperty("message_uuid")]
        public string MessageUuid { get; set; }
        [JsonProperty("message_type")]
        public string MessageType { get; set; }
        [JsonProperty("publish_time")]
        public DateTime PublishTime { get; set; }
    }
}
