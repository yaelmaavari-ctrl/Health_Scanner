using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Barcode { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = null!;

        [MaxLength(150)]
        public string? Brand { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();
        public ICollection<ProductNutrient> ProductNutrients { get; set; } = new List<ProductNutrient>();
        public ICollection<ScanHistory> ScanHistories { get; set; } = new List<ScanHistory>();
    }
}