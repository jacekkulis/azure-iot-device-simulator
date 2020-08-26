using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace PLodz.MonitoringSystem.DeviceSimulator.Configuration
{
    public class AzureConfiguration
    {
        [JsonProperty("iothub_registry_connection_string")]
        public string RegistryConnectionString { get; set; }
        [JsonProperty("iothub")]
        public string IotHub { get; set; }
    }


    public class MessageSequenceItem
    {
        private const int _defaultIterations = 1;
        private const int _defaultDelay = 1000;

        [JsonProperty("type")]
        public string MessageType { get; set; }
        [DefaultValue(_defaultIterations)]
        [JsonProperty("iterations")]
        public int Iterations { get; set; }

        [DefaultValue(_defaultDelay)]
        [JsonProperty("delay")]
        public int Delay { get; set; }
    }

    public class SimulationConfiguration
    {
        private const int _defaultIterations = int.MaxValue;

        [JsonProperty("azure_config")]
        public AzureConfiguration AzureConfig { get; set; }

        [JsonProperty("devices")]
        public List<string> Assets { get; set; }

        [JsonProperty("min_delay")]
        public int MinDelay { get; set; }

        [JsonProperty("max_delay")]
        public int MaxDelay { get; set; }
        [JsonProperty("iterations")]
        [DefaultValue(_defaultIterations)]
        public int Iterations { get; set; }

        [JsonProperty("message_sequence")]
        public List<MessageSequenceItem> SequenceItems { get; set; }

        private SimulationConfiguration() { }

        public static SimulationConfiguration LoadFromFile(string configurationFile)
        {
            return JsonConvert.DeserializeObject<SimulationConfiguration>(File.ReadAllText(configurationFile));
        }
    }
}
