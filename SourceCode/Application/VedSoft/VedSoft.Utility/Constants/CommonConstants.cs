using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Utility.Constants
{
    public class ApiCallConstants
    {
        public static string GetCommonAPIAddress(string apiUrl, string actionName)
        {
            return string.Format("{0}/{1}", apiUrl, actionName);
        }
        public static string ContentTypeJSON
        {
            get { return "application/json"; }
        }
        public static string APICallingLanguageKey
        {
            get { return "Accept-Language"; }
        }
        public static string APICallingLanguageValue
        {
            get { return "en-US"; }
        }

    }
}
