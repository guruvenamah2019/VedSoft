using System;
using System.Collections.Generic;
using System.Text;

namespace VedSoft.Model.Common
{
    public class ResultModel
    {
        public bool IsException { get; set; }
        public int ResultValue { get; set; }
        public object ReturnValue { get; set; }
        public IList<object> Returnlist { get; set; }

        public int PrimaryKey { get; set; }

        public ResultModel()
        {
            ResultValue = 0;
            ReturnValue = false;
            IsException = false;
            Returnlist = null;
        }
    }
}
