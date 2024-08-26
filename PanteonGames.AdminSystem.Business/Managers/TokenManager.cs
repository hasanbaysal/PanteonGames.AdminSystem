using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PanteonGames.AdminSystem.Business.Services;
using PanteonGames.AdminSystem.Helper.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PanteonGames.AdminSystem.Business.Managers
{
    public class TokenManager : ITokenService
    {
        private readonly CustomTokenOption tokenOption;

        public TokenManager(IOptions<CustomTokenOption> options)
        {
            tokenOption = options.Value;
        }
        public string GetToken(int id, string userName, string email)
        {

            var claimList = new List<Claim>();

            claimList.Add(new Claim("UserId", id.ToString()));
            claimList.Add(new Claim("UserName", userName));
            claimList.Add(new Claim("Email", email));


            var accessTokenExpiration = DateTime.Now.AddMinutes(tokenOption.AccessTokenExpiration);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            JwtSecurityToken jwtSecurityToken = new
               JwtSecurityToken(

                   issuer: tokenOption.Issuer,
                   expires: accessTokenExpiration,
                   notBefore: DateTime.Now,
                   audience: tokenOption.Audience,
                   claims: claimList,
                   signingCredentials: signingCredentials

               );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
