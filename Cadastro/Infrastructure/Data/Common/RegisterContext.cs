using Cadastro.Domain.Entities;
using Cadastro.Infrastructure.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using Cadastro.ViewModels;

namespace Cadastro.Infrastructure.Data.Common
{
    public class RegisterContext : DbContext
    {
        public RegisterContext(DbContextOptions<RegisterContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }

        public DbSet<Cadastro.ViewModels.ProductViewModels> ProductViewModels { get; set; }
    }
}
