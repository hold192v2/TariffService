﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffService.Domain.Entities
{
    public class TariffCartDTO
    {
        public Guid UserId { get; set; }
        public Guid CardId { get; set; }
        public Tariff Tarriff { get; set; }
        public string NewPhone { get; set; }


    }
}
