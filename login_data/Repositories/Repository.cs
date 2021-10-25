using login_infrastructure.Data;
using login_infrastructure.Entities;
using login_infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace login_infrastructure.Repository
{
    public class Repository : IRepository
    {
        private readonly LoginDbContext _dbContext;

        public Repository(LoginDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Account>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Account> GetByEmailAsync(string email)
        {
            return await _dbContext.Set<Account>().SingleOrDefaultAsync(e => e.Email == email);
        }

        public async Task<List<Account>> ListAsync()
        {
            return await _dbContext.Set<Account>().ToListAsync();
        }

        public async Task<List<Account>> ListAsync(string[] includes)
        {
            var list = _dbContext.Set<Account>().AsQueryable();
            return await includes.Aggregate(list.AsQueryable(), (query, path) => query.Include(path)).ToListAsync();
        }

        public async Task<Account> AddAsync(Account entity)
        {
            _dbContext.Set<Account>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(Account entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Account entity)
        {
            _dbContext.Set<Account>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await DeleteAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}