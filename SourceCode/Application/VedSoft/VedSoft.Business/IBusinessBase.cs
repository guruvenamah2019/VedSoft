using System;
using VedSoft.Data.Contracts.Wrapper;

namespace VedSoft.Business
{
    public interface IBusinessBase
    {
        IRepositoryWrapper RepositoryWrapper { get; set; }
    }
}
