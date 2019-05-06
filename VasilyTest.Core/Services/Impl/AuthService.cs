using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VasilyTest.Core.Helpers;

namespace VasilyTest.Core.Services.Impl
{
    public class AuthService : IAuthService
    {
        private List<User> _users = new List<User>
        {
            new User { Username = "test", Password = "test" }
        };

        private readonly AppSettings _appSettings;

        public AuthService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public RequestResult<string> Authenticate(string username, string password)
        {
            var result = new RequestResult<string>();

            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                result.StatusCode = StatusCodes.Status401Unauthorized;
                return result;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            result.Obj = tokenHandler.WriteToken(token);
            return result;
        }
    }
}
