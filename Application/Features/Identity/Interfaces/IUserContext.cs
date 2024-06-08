using Application.Features.Identity.Dtos;

namespace Application.Features.Identity.Interfaces
{
    public interface IUserContext
    {
        CurrentUserDto? GetCurrentUser();
    }
}