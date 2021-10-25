using login_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace login_infrastructure.Data
{
    public interface ILoginDbContext
    {
        DbSet<Account> Accounts { get; set; }
    }
}