using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffService.Domain.Entities
{
    public class ServiceBase : BaseEntity
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string MeasureUnit { get; set; }
        public List<int>? Values { get; set; } // Для динамических тарифов
        public decimal? Price { get; set; } // Цена за единицу
        public int? Amount { get; set; } // Выбранное количество
        public string? ImageUrl { get; set; } // Для приложений и дополнительных услуг
        public string? LabelForOverview { get; set; } // Описание услуги
    }
}
