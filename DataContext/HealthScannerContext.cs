using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System.Threading.Tasks;

namespace DataContext
{
    public class HealthScannerContext : DbContext, Icontext
    {
        private readonly string _connection;
        public HealthScannerContext(string connectionString)
        {
            _connection = connectionString;
        }

        // DbSets
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCondition> UserConditions { get; set; }
        public virtual DbSet<ScanHistory> ScanHistories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductIngredient> ProductIngredients { get; set; }
        public virtual DbSet<ProductNutrient> ProductNutrients { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<MedicalCondition> MedicalConditions { get; set; }
        public virtual DbSet<ConditionRule> ConditionRules { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public async Task Save()
        {
            await SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }
    }
}