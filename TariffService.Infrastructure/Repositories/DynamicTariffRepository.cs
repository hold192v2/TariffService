using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Entities;
using TariffService.Domain.Interfaces;
using TariffService.Infrastructure.Context;

namespace TariffService.Infrastructure.Repositories
{
    public class DynamicTariffRepository : BaseRepository<DynamicTariff>, IDynamicTariff
    {
        private readonly AppDbContext _context;

        public DynamicTariffRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<DynamicTariff?> GetByHashId(string id)
        {
            return _context.DynamicTariffs.FirstOrDefault(x => x.Id == id);
        }
    }
}
