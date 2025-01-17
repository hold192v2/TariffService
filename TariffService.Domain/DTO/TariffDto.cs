using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbonents.Dtos
{
    public class TariffDto
    {
        public string TariffName { get; set; } = string.Empty;
        public decimal RemainGb { get; set; }
        public decimal RemainMin { get; set; }
        public decimal RemainSMS { get; set; }
        public bool UnlimVideo { get; set; }
        public bool UnlimSocials { get; set; }
        public bool UnlimMusic { get; set; }
        public bool LongDistanceCall { get; set; }
    }
}
