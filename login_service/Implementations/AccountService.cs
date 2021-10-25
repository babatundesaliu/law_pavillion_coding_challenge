using AutoMapper;
using login_infrastructure.Entities;
using login_infrastructure.Interface;
using login_service.DTOs;
using login_service.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace login_service.Implementations
{
    public class AccountService : IAccountService
    {
        // private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public AccountService(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }


        public async Task Register(AccountDTO model)
        {            
            var existing = await _repository.GetByEmailAsync(model.Email);
            if (existing != null)
            {
                return;
            }
            
            var account = _mapper.Map<Account>(model);                               

            account.PasswordHash = BC.HashPassword(model.Password);

            await _repository.AddAsync(account);
        }
    }
}
