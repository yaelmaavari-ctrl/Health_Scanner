using Repository.Entities;
using Microsoft.EntityFrameworkCore;
namespace Repository.Interfaces
{
    public interface Icontext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserCondition> UserConditions { get; set; }
        public DbSet<ScanHistory> ScanHistories { get; set; }
        public DbSet<ProductNutrient> ProductNutrients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MedicalCondition> MedicalConditions { get; set; }
        public DbSet<ConditionRule> ConditionRules { get; set; }
        public DbSet<Category> Categories { get; set; }
        public Task Save();
    }
}
