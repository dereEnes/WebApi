using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entites;
using WebApi.TokenOperations.Models;

namespace WebApi.TokenOperations{
    public class TokenHandler{
        private readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Token CreateAccessToken(User user){
            Token token = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);
            token.ExpirationDate = DateTime.Now.AddMinutes(15);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer:_configuration["Token:Issuer"],
                audience:_configuration["Token:Audience"],
                expires:token.ExpirationDate,
                notBefore:DateTime.Now,
                signingCredentials:credentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //Token yaratılıyor.
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();
            return token;
        }
        public string CreateRefreshToken(){
            return Guid.NewGuid().ToString();
        }
    }
}