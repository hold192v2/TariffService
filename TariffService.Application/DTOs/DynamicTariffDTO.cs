using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffService.Application.DTOs
{
    public class DynamicTariffDTO
    {
        public decimal Minutes { get; set; }
        public decimal Gigabytes { get; set; }
        public decimal Sms { get; set; }
        public bool UnlimVideo { get; set; }
        public bool UnlimSocials { get; set; }
        public bool UnlimMusic { get; set; }
        public bool LongDistanceCall { get; set; }
    }
}
