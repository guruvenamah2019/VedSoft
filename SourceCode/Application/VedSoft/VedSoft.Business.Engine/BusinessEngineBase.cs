using System;
using VedSoft.Data.Contracts.Wrapper;

namespace VedSoft.Business
{
    public class BusinessEngineBase:IBusinessEngineBase
    {
        public IRepositoryWrapper RepositoryWrapper { get; set; }
    }
}
