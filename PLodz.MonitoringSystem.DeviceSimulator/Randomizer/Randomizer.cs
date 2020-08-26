using System;
using System.Linq;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    public class Randomizer : IRandomizer
    {
        public readonly Random _random;

        public Randomizer()
        {
            _random = new Random(Guid.NewGuid().GetHashCode());
        }

        #region Public methods

        public float NextFloat(float min, float max, int decimals)
        {
            return (float)NextDouble(min, max, decimals);
        }

        public double NextDouble(float min, float max, int decimals)
        {
            return Round(_random.NextDouble() * (max - min) + min, decimals);
        }

        public int NextInt(int min, int max)
        {
            return _random.Next(min, max);
        }

        public Guid NextGuid()
        {
            return Guid.NewGuid();
        }

        public string NextString(int minLength = 5, int maxLength = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, _random.Next(minLength, maxLength))
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        #endregion

        #region Private methods

        private static double Round(double input, int decimals)
        {
            if (decimals >= 0 && decimals <= 30)
            {
                return Math.Round(input, decimals);
            }

            return Math.Round(input, 2);
        }

        #endregion
    }
}
