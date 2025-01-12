using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffService.Domain.Requests
{
    public record StaticTariffsRequest(int PageNumber,
    string? Name,
    decimal? Price,
    decimal? Minutes,
    decimal? Gigabytes,
    decimal? Sms,
    bool? UnlimVideo,
    bool? UnlimSocials,
    bool? UnlimMusic,
    bool? LongDistanceCall,
    bool? Status);
}
