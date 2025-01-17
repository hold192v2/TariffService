using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Entities;

namespace ServiceAbonents.Dtos
{
    public class TransferDataAbonentDto
    {
        public string PhoneNumber { get; set; }
        public string TariffId { get; set; }
        public decimal TariffCost { get; set; }
        public TariffDto dataTariff { get; set; }
    }
}
