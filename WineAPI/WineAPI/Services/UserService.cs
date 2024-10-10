using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WineAPI.Helpers;
using WineCode.Data;
using WineCode.Models;

namespace WineAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly WineContext _wineContext;

        public UserService(IOptions<AppSettings> appSettings,  WineContext wineContext)
        {
            _appSettings = appSettings.Value;
            _wineContext = wineContext;
        }

        public User Authenticate(string username, string password)
        {
            var user = _wineContext.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            if (user == null) {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId",user.UserId.ToString()),
                    new Claim("Username", user.UserName)
                    }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            // remove password before returning
            user.Password = null;
            return user; 
        }
    }

}
