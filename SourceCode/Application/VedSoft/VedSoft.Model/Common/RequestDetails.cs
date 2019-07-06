using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Model.Common
{
    public class RequestDetails
    {
        public string ContentHeader { get; set; }
        public string Header { get; set; }
        public string Method { get; set; }
        public string FromURL { get; set; }
    }
}
