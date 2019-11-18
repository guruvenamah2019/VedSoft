using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VedSoft.Model.Common
{
    public class RequestModel<T> where T : class
    {
        public T RequestParameter { get; set; }
        public int APIClientId { get; set; }
        public int? CustomerId { get; set; }
        public string ObjectKey { get; set; }
        public string RequestTxnID { get; set; }
        public int? LanguageId { get; set; }
        public int? LoginUserId { get; set; }
    }

    public class SearchRequestModel<T> : RequestModel<T> where T : class
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class ContactNumber
    {
        public string Landline { get; set; }
        public string Mobile { get; set; }
    }

    public class OtherInfo
    {
        public string OtherInfo1 { get; set; }
        public string OtherInfo2 { get; set; }
    }
}
