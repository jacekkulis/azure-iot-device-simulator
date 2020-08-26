using System;
using PLodz.MonitoringSystem.DeviceSimulator.Models;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    public static class MessageGenerator
    {
        public static IMessage CreateInstance(string messageType)
        {
            switch (messageType)
            {
                case "telemetry":
                    var telemetryMsg = new TelemetryMessage();

                    return telemetryMsg;
                case "event":
                    var eventMsg = new EventMessage();

                    return eventMsg;
                default:
                    throw new ArgumentNullException("Unknown message type.");
                    break;
            }
            return null;
        }
    }
}
