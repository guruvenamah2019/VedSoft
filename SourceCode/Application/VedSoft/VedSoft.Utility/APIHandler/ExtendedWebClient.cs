using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VedSoft.Utility.Constants;
 
namespace VedSoft.Utility.APIHandler
{
    public class ExtendedWebClient : WebClient
    {
        public int Timeout { get; set; }       ///IN millisecond 

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request != null)
                request.Timeout = Timeout;
            return request;
        }


        public ExtendedWebClient()
        {
            Encoding = Encoding.UTF8;
            Timeout = 550000; // the standard HTTP Request Timeout default
            Headers[HttpRequestHeader.ContentType] =ApiCallConstants.ContentTypeJSON;
            Headers.Add(ApiCallConstants.APICallingLanguageKey, ApiCallConstants.APICallingLanguageValue);
        }
    }
}
