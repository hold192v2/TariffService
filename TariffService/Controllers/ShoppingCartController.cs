﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TariffService.Application.UseCases.CartUseCases.SaveTariffCart;
using TariffService.Domain.Interfaces;

namespace TariffService.Controllers
{
    [ApiController]
    [Route("shopCart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITariffCart _tariffCart;

        public ShoppingCartController(IMediator mediator, ITariffCart tariffCart)
        {
            _mediator = mediator;
            _tariffCart = tariffCart;
        }
        [HttpPost("saveTariffCart")]
        public async Task<IActionResult> SaveTariffCart([FromBody] SaveTariffCartRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            if (response is null) return BadRequest();
            return Ok(response.CartCount);
        }
        [HttpGet("getTariffCart/{id}")]
        public async Task<IActionResult> GetTariffCart(Guid userId)
        {
            try
            {
                var tariffCart = await _tariffCart.GetAllUserTariffCart(userId);
                return Ok(tariffCart);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to save phone number: {ex.Message}");
            }
        }

    }
}
