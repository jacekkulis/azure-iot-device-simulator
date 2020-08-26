using System;
using PLodz.MonitoringSystem.DeviceSimulator.Models;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    public static class MessageFactory
    {
        public static IMessage CreateInstance(string messageType)
        {
            switch (messageType)
            {
                case "telemetry":
                    return Activator.CreateInstance<TelemetryMessage>();
                case "event":
                    return Activator.CreateInstance<EventMessage>();
                default:
                    throw new ArgumentNullException("Unknown message type.");
                    break;
            }
            return null;
        }
    }
}
