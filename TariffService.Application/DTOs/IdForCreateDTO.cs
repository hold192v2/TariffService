using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffService.Application.DTOs
{
    public class IdForCreateDTO
    {
        public Guid AbonentId { get; set; }
        public Guid TemporaryId { get; set; }
    }
}
