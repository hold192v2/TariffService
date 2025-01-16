using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Entities;

namespace TariffService.Application.DTOs
{
    public class ListTransferDataAbonentDto
    {
        public List<TariffCartDTO> tariffCartDTOs {get; set;}
    }
}
