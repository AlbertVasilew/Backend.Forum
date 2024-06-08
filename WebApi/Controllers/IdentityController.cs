using Application.Features.Identity.Commands.Login;
using Application.Features.Identity.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator mediator;

        public IdentityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await mediator.Send(request);
            return string.IsNullOrEmpty(response.Token) ? Unauthorized() : Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await mediator.Send(request);

            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok();
        }
    }
}