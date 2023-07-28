using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Models.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Repositories
{
    public class Tokenhandler : ITokenhandler
    {
        private readonly IConfiguration Configuration;
        public Tokenhandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        public Task<string> CreateTokenAsyn(Users User)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName , User.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, User.LastName));
            claims.Add(new Claim(ClaimTypes.Email, User.EmailAddress));

            User.Roles.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            );

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new  SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                Configuration["Jwt:Issuer"],
                Configuration["Jwt:Audience"],
                claims,
                expires:DateTime.Now.AddMinutes(15),
                signingCredentials:credentials
                );
            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }
    }

}
