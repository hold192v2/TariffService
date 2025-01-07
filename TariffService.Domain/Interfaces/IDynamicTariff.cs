using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Entities;

namespace TariffService.Domain.Interfaces
{
    public interface IDynamicTariff : IBaseOperationRepository<DynamicTariff>
    {
        Task<DynamicTariff?> GetByHashId(string id);
    }
}
