using Application.Features.Identity.Dtos;
using Application.Identity.Interfaces;
using MediatR;

namespace Application.Features.Identity.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, IdentityLoginResultDto>
    {
        private readonly IIdentityService identityService;

        public LoginHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        public async Task<IdentityLoginResultDto> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var result = await identityService.LoginAsync(request.Email, request.Password);
            return new IdentityLoginResultDto { Token = result.Token };
        }
    }
}