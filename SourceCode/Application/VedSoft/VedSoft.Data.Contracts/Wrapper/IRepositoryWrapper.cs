using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Master;

namespace VedSoft.Data.Contracts.Wrapper
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository CustomerRepository { get; }
    }
}
