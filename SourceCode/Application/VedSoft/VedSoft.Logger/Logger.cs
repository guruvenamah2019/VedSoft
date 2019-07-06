using log4net;
using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Logger;

namespace VedSoft.Logger
{
    public class Logger: IVedSoftLogger
    {
        public ILog Log4NetCore { get; set; }
        public void LogError(string message)
        {
            Log4NetCore.Error(message);
        }

        public void LogInfo(string message)
        {
            Log4NetCore.Info(message);
        }
    }
}
