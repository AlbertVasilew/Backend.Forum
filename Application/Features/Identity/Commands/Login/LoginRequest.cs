using Application.Features.Identity.Dtos;
using MediatR;

namespace Application.Features.Identity.Commands.Login
{
    public class LoginRequest : IRequest<IdentityLoginResultDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}