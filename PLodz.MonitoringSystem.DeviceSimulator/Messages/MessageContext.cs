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
        public SimulationConfiguration Config { get; set; }

        public string AssetId { get; set; }


        public List<IMessage> Messages { get; set; }

        public Logger Logger { get; set; }

        private readonly Random _rnd = new Random(Guid.NewGuid().GetHashCode());

        public float Random(float min, float max)
        {
            return (float)_rnd.NextDouble() * (max - min) + min;
        }

        public double Random(double min, double max, int decimals = -1)
        {
            if (decimals == -1)
            {
                decimals = 2;
            }

            var result = _rnd.NextDouble() * (max - min) + min;
            if (decimals >= 0)
            {
                result = Math.Round(result, decimals);
            }

            return result;
        }

        public int Random(int min, int max)
        {
            return _rnd.Next(min, max);
        }

        public int RandomInteger(int min = 0, int max = 100)
        {
            return _rnd.Next(min, max);
        }

        public int EpochTimestamp()
        {
            return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public string RandomString(int minLength = 5, int maxLength = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, _rnd.Next(minLength, maxLength))
                .Select(s => s[_rnd.Next(s.Length)]).ToArray());
        }

        public Coordinates Coordinates()
        {
            // TODO: Only gothenburg at the moment
            return new Coordinates(57.71531307f, 12.00476071f);
        }

        public MessageContext(string assetId, SimulationConfiguration config, Logger.LogLevel logLevel)
        {
            AssetId = assetId;
            Messages = new List<IMessage>();

            Config = config;

            Logger = new Logger(logLevel);
        }

        public bool RandomBoolean()
        {
            return _rnd.Next(0, 2) == 1;
        }
    }

    public class Coordinates
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public Coordinates(float latitude, float longitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
