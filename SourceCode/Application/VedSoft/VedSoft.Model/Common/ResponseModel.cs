using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Model.Common
{
    public class ResponseModel<T> where T : class
    {
        public T ResponseData { get; set; }
        public string ResponseTxnID { get; set; }
        public decimal? Status { get; set; }
        public string Message { get; set; }
        public string ResponseApiVersion { get; set; }
    }


}
