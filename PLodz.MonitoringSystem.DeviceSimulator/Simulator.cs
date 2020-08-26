using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using PLodz.MonitoringSystem.DeviceSimulator.Configuration;
using PLodz.MonitoringSystem.DeviceSimulator.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TransportType = Microsoft.Azure.Devices.Client.TransportType;

namespace PLodz.MonitoringSystem.DeviceSimulator
{
    public class SimulationResult
    {
        public bool Succeeded { get; set; }

        public SimulationResult(bool succeeded)
        {
            Succeeded = succeeded;
        }
    }

    public class Simulator
    {
        private readonly RegistryManager _regMngr;
        private readonly SimulationConfiguration _config;
        private readonly MessagePropagator _propagator = new MessagePropagator();

        public Simulator(SimulationConfiguration config)
        {
            _regMngr = RegistryManager.CreateFromConnectionString(config.AzureConfig.RegistryConnectionString);
            _config = config;
        }

        public async Task<SimulationResult> Start()
        {
            var cancellationTok = new CancellationToken();
            return await Start(cancellationTok);
        }

        public async Task<SimulationResult> Start(CancellationToken cancelToken)
        {

            var tasks = new List<Task<SimulationResult>>();

            foreach (var asset in _config.Assets)
            {
                tasks.Add(SendSequence(asset, cancelToken));
            }

            await Task.WhenAll(tasks);

            return new SimulationResult(true);
        }

        public async Task<SimulationResult> SendSequence(string assetId, CancellationToken cancelToken)
        {
            if (_config.MinDelay > 0)
            {
                var delay = new Random(Guid.NewGuid().GetHashCode()).Next(_config.MinDelay, _config.MaxDelay);
                Console.WriteLine($"Delaying session by {delay}");
                await Task.Delay(delay, cancelToken);
            }

            var iothubPropagatorId = Guid.Empty;

            var device = await _regMngr.GetDeviceAsync(assetId, cancelToken);
            var client = DeviceClient.Create(_config.AzureConfig.IotHub,
                new DeviceAuthenticationWithRegistrySymmetricKey(assetId,
                    device.Authentication.SymmetricKey.PrimaryKey), TransportType.Mqtt);

            iothubPropagatorId = _propagator.RegisterMessageSender<IoTHubMessageSender>(client);


            for (var i = 0; i < _config.Iterations; i++)
            {
                // Create a session context for each propagator
                var contexts = new List<MessageContext>();
                var sessionId = Guid.NewGuid().ToString().ToUpper();

                contexts.Add(new MessageContext(assetId, _config, Logger.LogLevel.Error));

                foreach (var item in _config.SequenceItems)
                {
                    contexts[0].Logger.LogInformation($"Sending message: {item.MessageType}...");
                    await _propagator.SendMessage(contexts, item.MessageType);
                    Thread.Sleep(5000);
                }
            }

            if (iothubPropagatorId != Guid.Empty)
            {
                _propagator.UnregisterMessageSender(iothubPropagatorId);
            }

            return new SimulationResult(true);
        }
    }
}
