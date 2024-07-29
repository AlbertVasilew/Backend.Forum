using Application.Identity.Interfaces;
using MediatR;

namespace Application.Features.Identity.Commands.Register
{
    public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        private readonly IIdentityService identityService;

        public RegisterHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var result = await identityService.RegisterAsync(request.Email, request.Username, request.Password);
            return new RegisterResponse { Errors = result.Errors };
        }
    }
}