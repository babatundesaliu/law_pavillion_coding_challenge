using login_infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace login_infrastructure.Interface
{
    public interface IRepository
    {
        Task<Account> GetByIdAsync(int id);
        Task<Account> GetByEmailAsync(string email);
        Task<List<Account>> ListAsync();
        Task<Account> AddAsync(Account entity);
        Task UpdateAsync(Account entity);
        Task DeleteAsync(Account entity);
        Task DeleteAsync(int id);
    }
}
