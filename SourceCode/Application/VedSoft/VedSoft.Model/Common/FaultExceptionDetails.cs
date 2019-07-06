using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Model.Common
{
    public class FaultExceptionDetails
    {
        public string Exception { get; set; }
        public string ExceptionType { get; set; }
        public string DbEntityValidationException { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
    }
}
