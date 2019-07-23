using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Model.Common
{
    public class ResultModel
    {
        public bool IsException { get; set; }
        public int StatusId { get; set; }
        public object ResponseValue { get; set; }
        public int PrimaryKey { get; set; }

        public ResultModel()
        {
            StatusId = 0;
            ResponseValue = false;
            IsException = false;
        }
    }
}
