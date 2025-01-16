using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffService.Domain.DTO
{
    public record CreatePublisherDTO(Guid userId, string phoneNumber, string tariffId, decimal price);
}
