using Application.Features.Identity.Dtos;

namespace Application.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<IdentityLoginResultDto> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<IdentityResultDto> RegisterAsync(string email, string username, string password);
    }
}