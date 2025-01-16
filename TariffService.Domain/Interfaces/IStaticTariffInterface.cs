using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Entities;
using TariffService.Domain.Requests;

namespace TariffService.Domain.Interfaces
{
    public interface IStaticTariffInterface : IBaseOperationRepository<StaticTariff>
    {
        Task<StaticTariff?> GetByNumberId(string id);
        Task<List<StaticTariff>> GetPaginationAndFilterTariffs(StaticTariffsRequest request, CancellationToken cancellationToken);
        Task<List<StaticTariff>> GetTrueTariffs();
    }
}
