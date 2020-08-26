using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

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

        [JsonIgnore]
        public abstract string MessageType { get; }

        #endregion

        public MessageBase()
        {
            this.Properties = new Dictionary<string, string>();
            this.Properties.Add("messageType", MessageType);
        }

        public abstract string Generate(MessageContext ctx);

        public Dictionary<string, string> GetProperties()
        {
            return Properties;
        }

        public string GetContentType()
        {
            return MediaTypeNames.Application.Json;
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this));
        }
    }
}
