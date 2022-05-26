﻿using System;
using System.IO;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class ConsoleLogWritter
    {
        public virtual void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FileLogWritter
    {
        public virtual void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class SecureConsoleLogWritter : ConsoleLogWritter
    {
        public override void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                base.WriteError(message);
            }
        }
    }
}
