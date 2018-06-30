using System;
using System.Text;
using System.Threading.Tasks;
using HLog.Contract;

namespace HLog
{
    public class ConsoleHLog : BaseLog
    {
        private static readonly ConsoleColor _defaultColor = Console.ForegroundColor;

        public ConsoleHLog() : this(new LogConfiguration())
        {
        }

        public ConsoleHLog(ILogConfig config) : base(config)
        {
            base.OutputStream = Console.OpenStandardOutput();
        }

        public override async Task Verbose(string text)
        {
            await this.WriteToConsole(text, ConsoleColor.Gray, Level.Verbose);
        }

        public override async Task Info(string text)
        {
            await this.WriteToConsole(text, ConsoleColor.Green, Level.Info);
        }

        public override async Task Error(string text)
        {
            await this.WriteToConsole(text, ConsoleColor.DarkYellow, Level.Error);
        }

        public override async Task Critical(string text)
        {
            await this.WriteToConsole(text, ConsoleColor.Red, Level.Critical);
        }

        public override async Task Fatal(string text)
        {
            await this.WriteToConsole(text, ConsoleColor.Red, Level.Fatal);
        }

        private async Task WriteToConsole(string text, ConsoleColor color, Level level)
        {
            try
            {
                Console.ForegroundColor = color;
                await base.WriteMessage(text, level);
                Console.ForegroundColor = _defaultColor;
            }
            catch (Exception)
            {
                Console.ForegroundColor = _defaultColor;
            }

        }
    }
}
