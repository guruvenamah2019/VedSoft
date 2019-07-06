using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using log4net;

namespace VedSoft.Logger
{
    /// <summary>
    /// Interface for logging
    /// </summary>
    public interface IVedSoftLogger
    {
        void LogError(string message);
        void LogInfo(string message);
        ILog Log4NetCore { get; set; }
    }
}
