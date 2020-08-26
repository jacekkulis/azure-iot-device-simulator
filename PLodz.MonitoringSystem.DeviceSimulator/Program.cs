using PLodz.MonitoringSystem.DeviceSimulator.Configuration;
using System;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = SimulationConfiguration.LoadFromFile("appSettings.json");
            var sim = new Simulator(config);
            sim.Start().Wait();

            Console.ReadLine();
        }
    }
}
