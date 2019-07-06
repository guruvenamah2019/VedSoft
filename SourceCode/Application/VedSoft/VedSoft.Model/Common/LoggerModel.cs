using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Model.Common
{
    public class LoggerModel
    {
        public string UniqueKey { get; set; }
        public RequestDetails RequestDetails { get; set; }
        public string RequestParameter { get; set; }
        public string Response { get; set; }
        public FaultExceptionDetails ErrorDetails { get; set; }
        public Int64 TimeTakenMS { get; set; }
    }
}
