using System;

namespace WebApi.Services
{
    public class DbLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - {0}",message);
        }
    }
}