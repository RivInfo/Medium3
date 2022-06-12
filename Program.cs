using System;
using System.IO;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Pathfinder pathfinder1 = new Pathfinder(new FileLogWritter());
            Pathfinder pathfinder2 = new Pathfinder(new ConsoleLogWritter());
            Pathfinder pathfinder3 = new Pathfinder(new SecureConsoleLogWritter());
            Pathfinder pathfinder4 = new Pathfinder(new SecureFileLogWritter());
            Pathfinder pathfinder5 = new Pathfinder(new SpecialFileLogWritter());
        }
    }

    class Pathfinder
    {
        private ILogger _logger;

        public Pathfinder(ILogger logger)
        {
            _logger = logger;
        }

        public void Find(string message)
        {
            _logger.WriteError(message);
        }
    }

    interface ILogger
    {
        public void WriteError(string message);
    }

    class ConsoleLogWritter: ILogger
    {
        public virtual void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FileLogWritter: ILogger
    {
        public virtual void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class SecureConsoleLogWritter : ConsoleLogWritter, ILogger
    {
        public override void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                base.WriteError(message);
            }
        }
    }

    class SecureFileLogWritter : FileLogWritter, ILogger
    {
        public override void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                base.WriteError(message);
            }
        }
    }

    class SpecialFileLogWritter : SecureFileLogWritter, ILogger
    {
        public override void WriteError(string message)
        {
            Console.WriteLine(message);
            base.WriteError(message);
        }
    }
}
