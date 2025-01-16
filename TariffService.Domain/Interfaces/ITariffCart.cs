using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.DTO;
using TariffService.Domain.Entities;

namespace TariffService.Domain.Interfaces
{
    public interface ITariffCart : IBaseOperationRepository<TariffCart>
    {
        public Task<List<TariffCartDTO>> GetAllUserTariffCart(Guid userId);
        public Task<int> GetCartCount(Guid userId);
        public Task<List<CreateCartDTO>> GetAllUserTariff(Guid userId, Guid temporaryUserId);
        public Task DeleteById(Guid cardId, Guid userId);
        public Task DeleteAll(Guid userId);
    }
}
