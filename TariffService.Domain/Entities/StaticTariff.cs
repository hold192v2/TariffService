using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffService.Domain.Entities
{
    public class StaticTariff : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Minutes { get; set; }
        public decimal Gigabytes { get; set; }
        public decimal Sms { get; set; }
        public bool UnlimVideo { get; set; }
        public bool UnlimSocials { get; set; }
        public bool UnlimMusic { get; set; }
        public bool LongDistanceCall { get; set; }
        public bool Status { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        protected StaticTariff() => Id = Guid.NewGuid();

    }
}
