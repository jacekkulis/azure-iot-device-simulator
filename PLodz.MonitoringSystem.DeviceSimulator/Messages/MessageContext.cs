using PLodz.MonitoringSystem.DeviceSimulator.Configuration;
using PLodz.MonitoringSystem.DeviceSimulator.Helpers;
using PLodz.MonitoringSystem.DeviceSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    public class MessageContext
    {
        public IRandomizer Randomizer { get; }

        public string AssetId { get; set; }

        public Logger Logger { get; set; }

        public MessageContext(string assetId, Logger.LogLevel logLevel)
        {
            AssetId = assetId;

            Logger = new Logger(logLevel);

            Randomizer = new Randomizer();
        }
    }
}
