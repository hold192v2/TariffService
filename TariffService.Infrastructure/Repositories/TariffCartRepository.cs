using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Interfaces;
using TariffService.Infrastructure.Context;

namespace TariffService.Infrastructure.Repositories
{
    public class TariffCartRepository : BaseRepository<TariffCart>, ITariffCart
    {
        private readonly AppDbContext _appDbContext;

        public TariffCartRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<List<TariffCart>> GetAllUserTariffCart(Guid userId)
        {
            return _appDbContext.TariffCarts.Where(tariff => tariff.TempUserId == userId).ToListAsync();
        }

        public Task<int> GetCartCount(Guid userId)
        {
            return _appDbContext.TariffCarts.Where(tariff => tariff.TempUserId == userId).CountAsync();
        }
    }
}
