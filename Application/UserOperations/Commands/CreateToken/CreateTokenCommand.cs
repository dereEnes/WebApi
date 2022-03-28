using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.DBOperations;
using WebApi.Entites;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Commands.CreateToken{
    public class CreateTokenCommand{
        public CreateTokenModel Model {get;set;}
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenCommand(IBookStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle(){
            
            var user = _dbContext.Users.FirstOrDefault( u => u.Email == Model.Email || u.Password == Model.Password);

            if(user is null) throw new InvalidOperationException("Kullanıcı bulunamadı!");
            
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.ExpirationDate.AddMinutes(5);
            _dbContext.SaveChanges();
            return token;
        }
        
    }
    public class CreateTokenModel{
        public string Email { get; set; }
        public string Password { get; set; }
    }
}