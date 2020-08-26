using Newtonsoft.Json;

namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public class TelemetryData : IBody
    {
        public double? a { get; set; }
        public double? v { get; set; }
        public double? p { get; set; }
        public double? wire_speed { get; set; }
        public double gas_flow { get; set; }
    }
}
