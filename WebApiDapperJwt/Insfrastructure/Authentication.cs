using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HoltiHubDapper.Entities;
namespace HoltiHubDapper.Insfrastructure
{
    public class Authentication
    {
        public static string GenerateToken(UserEntity user)
        {

            string userName = user.Name.IsNullOrEmpty() ? "teste" : user.Name.ToString();
            string userEmail = user.Email.IsNullOrEmpty() ? "teste" : user.Email.ToString();

            var key = Encoding.ASCII.GetBytes("62014CAFD11F65525B3BC8680F4D435C");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Email, userEmail)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        internal static string GenerateToken(string? email)
        {
            throw new NotImplementedException();
        }
    }
}

