﻿using System.Threading.Tasks;

namespace HLog.Contract
{
    public interface ILog
    {
        Task Verbose(string text);

        Task Info(string text);

        Task Error(string text);

        Task Critical(string text);

        Task Fatal(string text);
    }
}
