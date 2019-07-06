using Microsoft.EntityFrameworkCore;
using System;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;

namespace VedSoft.Data.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<CustomerModelDB> Customer { get; set; }
    }
}
