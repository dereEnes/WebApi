using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.DBOperations;
using WebApi.Entites;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Commands.RefreshToken{
    public class RefreshTokenCommand{
        public string RefreshToken {get;set;}
        private readonly IBookStoreDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IBookStoreDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public Token Handle(){
            
            var user = _dbContext.Users.FirstOrDefault( u => u.RefreshToken == RefreshToken && u.RefreshTokenExpireDate > DateTime.Now);

            if(user is null) throw new InvalidOperationException("Geçerli bir refresh token bulunamadı!");
            
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.ExpirationDate.AddMinutes(5);
            _dbContext.SaveChanges();
            return token;
        }
        
    }
    
}