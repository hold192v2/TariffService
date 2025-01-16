using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Application.DTOs;
using TariffService.Application.HadlerResponse;

namespace TariffService.Application.UseCases.UpdateUserTariff
{
    public record CreateUserRequest(Guid UserId, Guid TemporaryId) : IRequest<Response>;
}
