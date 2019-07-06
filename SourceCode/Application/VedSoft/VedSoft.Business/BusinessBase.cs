using System;
using VedSoft.Data.Contracts.Wrapper;

namespace VedSoft.Business
{
    public class BusinessBase
    {
        public IRepositoryWrapper RepositoryWrapper { get; set; }
    }
}
