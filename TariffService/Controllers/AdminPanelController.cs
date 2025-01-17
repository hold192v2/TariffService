using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TariffService.Application.UseCases.CreateStaticTariff;
using TariffService.Application.UseCases.GetStaticTarrifs;
using TariffService.Application.UseCases.UpdateStaticTariffs;
using TariffService.Application.UseCases.UpdateUnitPrice;
using TariffService.Domain.Interfaces;

namespace TariffService.Controllers
{
    [ApiController]
    [Route("adminTariff")]
    public class AdminPanelController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStaticTariffInterface _staticTariff;
        public AdminPanelController(IMediator mediator, IStaticTariffInterface staticTariff)
        {
            _mediator = mediator;
            _staticTariff = staticTariff;
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
        [HttpGet("getStaticTrue")]
        public async Task<IActionResult> GetStaticTariffsTrue()
        {
            var tariffs = await _staticTariff.GetTrueTariffs();
            return Ok(tariffs);
        }
        [HttpPut("updateUnitPrice")]
        public async Task<IActionResult> UpdateUnitPrice([FromBody] UpdateUnitPriceRequest request, CancellationToken cancellation)
        {
            return Ok();
        }
    }
}
