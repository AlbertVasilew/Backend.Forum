using MediatR;

namespace Application.Features.Identity.Commands.Register
{
    public class RegisterRequest : IRequest<RegisterResponse>
    {
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; } 
    }
}