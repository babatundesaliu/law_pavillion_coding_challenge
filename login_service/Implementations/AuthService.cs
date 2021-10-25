using AutoMapper;
using login_infrastructure.Entities;
using login_infrastructure.Interface;
using login_service.DTOs;
using login_service.Helpers;
using login_service.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace login_service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;
        private readonly AppSettings _appSettings;

        public AuthService(IRepository repository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _repository = repository;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {            
            var account = await _repository.GetByEmailAsync(model.Email);

            if (account == null || !BC.Verify(model.Password, account.PasswordHash))
                return new AuthenticateResponse();

            var response = _mapper.Map<AuthenticateResponse>(account);                   

            response.JwtToken = generateJwtToken(account);            
            return response;
        }

        private string generateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
