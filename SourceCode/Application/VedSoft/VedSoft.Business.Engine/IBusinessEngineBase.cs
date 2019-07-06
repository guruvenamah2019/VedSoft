using System;
using VedSoft.Data.Contracts.Wrapper;

namespace VedSoft.Business
{
    public interface IBusinessEngineBase
    {
        IRepositoryWrapper RepositoryWrapper { get; set; }
    }
}
