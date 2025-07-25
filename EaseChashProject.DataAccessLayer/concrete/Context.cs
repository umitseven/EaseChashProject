using EaseChashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EaseChashProject.DataAccessLayer.concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =UMIT\\SQLEXPRESS;initial catalog=EasyChashDb;integrated Security=true;TrustServerCertificate=True");
        }
        
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> customerAccountProcesses { get; set; }

    }
}
