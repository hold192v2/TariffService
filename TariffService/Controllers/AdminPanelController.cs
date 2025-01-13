using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TariffService.Application.UseCases.CreateStaticTariff;
using TariffService.Application.UseCases.GetStaticTarrifs;
using TariffService.Application.UseCases.UpdateStaticTariffs;
using TariffService.Application.UseCases.UpdateUnitPrice;

namespace TariffService.Controllers
{
    [ApiController]
    [Route("adminTariff")]
    public class AdminPanelController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminPanelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getStatic")]
        public async Task<IActionResult> GetStaticTariffs([FromQuery] GetStaticTariffsRequest query)
        {
            var tariffs = await _mediator.Send(query);
            return Ok(tariffs);
        }

        [HttpPost("createStaticTariff")]
        public async Task<IActionResult> CreateStaticTariff([FromBody] CreateStaticTariffRequest request, CancellationToken cancellation)
        {
            var response = await _mediator.Send(request, cancellation);
            if (response is null) return BadRequest();
            return Ok();
        }
        [HttpPut("updateStaticTariff")]
        public async Task<IActionResult> UpdateStaticTariff([FromBody] UpdateStaticTariffRequest request, CancellationToken cancellation)
        {
            var response = await _mediator.Send(request, cancellation);
            if (response is null) return BadRequest();
            return Ok();
        }
        [HttpPut("updateUnitPrice")]
        public async Task<IActionResult> UpdateUnitPrice([FromBody] UpdateUnitPriceRequest request, CancellationToken cancellation)
        {
            return Ok();
        }
    }
}
