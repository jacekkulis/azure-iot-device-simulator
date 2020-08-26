using System.Collections.Generic;

namespace PLodz.MonitoringSystem.DeviceSimulator.Models
{
    public interface IMessage
    {
        string Generate(MessageContext ctx);

        Dictionary<string, string> GetProperties();

        string GetContentType();

        byte[] GetBytes();
    }
}
