using login_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace login_infrastructure.Data
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}
