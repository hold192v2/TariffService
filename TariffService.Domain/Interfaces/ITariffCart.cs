using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffService.Domain.Interfaces
{
    public interface ITariffCart : IBaseOperationRepository<TariffCart>
    {
        Task<List<TariffCart>> GetAllUserTariffCart(Guid userId);
        Task<int> GetCartCount(Guid userId);
    }
}
