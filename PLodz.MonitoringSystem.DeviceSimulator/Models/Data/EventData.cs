using Newtonsoft.Json;

namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public class EventData : MessageDataBase
    {
        public string EventLevel { get; set; }
    }
}
