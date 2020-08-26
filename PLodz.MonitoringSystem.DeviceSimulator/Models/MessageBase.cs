using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Mime;

namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public abstract class MessageBase : IMessage
    {
        #region Properties

        [JsonIgnore]
        public Dictionary<string, string> Properties { get; set; }

        [JsonProperty("header")]
        public MessageHeader Header { get; set; }

        [JsonProperty("body")]
        public IBody Body { get; set; }

        public abstract string MessageType { get; }

        #endregion

        public MessageBase()
        {
            this.Properties = new Dictionary<string, string>();
            this.Properties.Add("messageType", MessageType);
        }

        public abstract string Generate(MessageContext ctx, bool keepState = false);

        public Dictionary<string, string> GetProperties()
        {
            return Properties;
        }

        public string GetContentType()
        {
            return MediaTypeNames.Application.Json;
        }
    }
}
