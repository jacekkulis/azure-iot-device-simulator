using Newtonsoft.Json;

namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public class EventData : IBody
    {
        public string EventInformation { get; set; }
        public string UnitType { get; set; }
        public string MachineId { get; set; }
        public string MachineName { get; set; }
        public string EventId { get; set; }
        public string SubError { get; set; }
        public string EventLevel { get; set; }
    }
}
