using Microsoft.EntityFrameworkCore;
using OCBTrainingMainInterface.Models;

namespace OCBTrainingMainInterface
{
    public class AppDbContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Turnover> Turnovers { get; set; }
        public DbSet<ClassTotal> ClassTotals { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Настройка моделей
        }
    }
}
