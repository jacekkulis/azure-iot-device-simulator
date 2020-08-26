using System;

namespace PLodz.MonitoringSystem.DeviceSimulator.Helpers
{
    public class Logger
    {
        public enum LogLevel
        {
            Debug = 1,
            Information = 2,
            Warning = 3,
            Error = 4
        }

        private readonly LogLevel _level;

        public Logger(LogLevel level)
        {
            _level = level;
        }

        public void LogDebug(string msg)
        {
            if ((int)_level >= 1)
            {
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[Debug ({DateTime.Now:HH:mm:ss})] {msg}");
                Console.ForegroundColor = oldColor;
            }
        }

        public void LogInformation(string msg)
        {
            if ((int)_level >= 2)
            {
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {msg}");
                Console.ForegroundColor = oldColor;
            }
        }


        public void LogWarning(string msg)
        {
            if ((int)_level >= 3)
            {
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {msg}");
                Console.ForegroundColor = oldColor;
            }
        }

        public void LogError(string msg)
        {
            if ((int)_level >= 4)
            {
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {msg}");
                Console.ForegroundColor = oldColor;
            }
        }
    }
}
