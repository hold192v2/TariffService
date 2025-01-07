using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Entities;

namespace TariffService.Domain.Interfaces
{
    public interface IStaticTariffInterface : IBaseOperationRepository<StaticTariff>
    {
        Task<StaticTariff?> GetByNumberId(int id);
        Task<List<StaticTariff>> GetPaginationTariffs(int page, int pageSize);
    }
}
