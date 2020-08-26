using Newtonsoft.Json;

namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public class TelemetryData : MessageDataBase
    {
        public double? Current { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double? Voltage { get; set; }
        public double? Power { get; set; }
    }
}
