using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.DTOs;
using TariffService.Application.HadlerResponse;

namespace TariffService.Application.UseCases.CartUseCases.SaveTariffCart
{
    public record SaveTariffCartRequest(Guid userId,string? staticTariffId, DynamicTariffDTO? tariff) : IRequest<Response>;
}
