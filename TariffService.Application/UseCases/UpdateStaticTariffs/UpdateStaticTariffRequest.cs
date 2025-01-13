using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.HadlerResponse;

namespace TariffService.Application.UseCases.UpdateStaticTariffs
{
    public record UpdateStaticTariffRequest(string Id,
    string Name,
    decimal Price,
    decimal Minutes,
    decimal Gigabytes,
    decimal Sms,
    bool UnlimVideo,
    bool UnlimSocials,
    bool UnlimMusic,
    bool LongDistanceCall,
    bool Status,
    string ImageUrl) :
        IRequest<Response>;
}
