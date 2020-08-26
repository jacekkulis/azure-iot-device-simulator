using System;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    public interface IRandomizer
    {
        float NextFloat(float min, float max, int decimals);

        double NextDouble(float min, float max, int decimals);

        int NextInt(int min, int max);

        Guid NextGuid();

        string NextString(int min, int max);
    }
}
