using System.Text;

namespace HLog.Contract
{
    public interface ILogConfig
    {
        Level LogLevel { get; }

        Encoding Encoding { get; }

        string TimeFormat { get; }
    }
}
