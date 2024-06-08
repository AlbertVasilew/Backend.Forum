using Application.Features.Identity.Dtos;
using Application.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IOptions<IdentityConfig> identityOptions;

        public IdentityService(UserManager<IdentityUser> userManager, IOptions<IdentityConfig> identityOptions)
        {
            this.userManager = userManager;
            this.identityOptions = identityOptions;
        }

        public async Task<IdentityLoginResultDto> LoginAsync(string email, string password)
        {
            var identityLoginResultDto = new IdentityLoginResultDto();
            var user = await userManager.FindByEmailAsync(email);

            if (user is not null && await userManager.CheckPasswordAsync(user, password))
            {
                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identityOptions.Value.Secret)),
                    SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                claims.AddRange(await userManager.GetClaimsAsync(user));

                var token = new JwtSecurityToken(
                    issuer: identityOptions.Value.Issuer,
                    audience: identityOptions.Value.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(identityOptions.Value.TokenExpirationHours),
                    signingCredentials: signingCredentials);

                identityLoginResultDto.Token = new JwtSecurityTokenHandler().WriteToken(token);
            }

            return identityLoginResultDto;
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResultDto> RegisterAsync(string email, string username, string password)
        {
            var result = await userManager.CreateAsync(
                new IdentityUser { Email = email, UserName = username }, password);

            return new IdentityResultDto { Errors = result.Errors.Select(x => x.Code).ToList() };
        }
    }
}