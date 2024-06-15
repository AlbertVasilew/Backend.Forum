using Application.Features.Identity.Dtos;
using Application.Features.Identity.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Identity
{

    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public CurrentUserDto? GetCurrentUser()
        {
            var user = httpContextAccessor?.HttpContext?.User;

            if (user is null)
                return null;

            return new CurrentUserDto
            {
                Id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value
            };
        }
    }
}