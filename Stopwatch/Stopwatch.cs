using System;

namespace Stopwatch
{
    public class Stopwatch
    {
        private static DateTime _startTime; 
        private static DateTime _stopTime;
        private static bool _isRunning = false;

        private static void Start()
        {
            if (!_isRunning)
            {
                _startTime = DateTime.Now;
                _isRunning = true;
            }
            else 
            {
                string message = "Stopwatch is already running.";
                throw new InvalidOperationException(message);
            }
        }

        private static TimeSpan Stop()
        {
            if (_isRunning)
            {
                _stopTime = DateTime.Now;
                _isRunning = false;
                return _stopTime - _startTime;
            }
            else
            {
                throw new InvalidOperationException("Stopwatch is not running.");
            }

        }

        
        public static void runStopwatch()
        {
            while (true)
            {
                Console.WriteLine("Enter a command (start/stop/exit):");
                string command = Console.ReadLine().ToString();

                switch (command)
                {
                    case "start":
                        try
                        {
                            Start();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "stop":
                        try
                        {
                            TimeSpan elapsed = Stop();
                            Console.WriteLine($"Elapsed time: {elapsed.TotalSeconds} seconds");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid command. Please enter 'start', 'stop', or 'exit'.");
                        break;
                }
            }
        }
    }
}