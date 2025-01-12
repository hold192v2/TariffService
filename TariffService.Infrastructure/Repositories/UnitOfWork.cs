using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Interfaces;
using TariffService.Infrastructure.Context;

namespace TariffService.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task Commit(CancellationToken cancellationToken)
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
