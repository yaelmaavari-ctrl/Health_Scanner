using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Barcode { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Brand { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();
        public ICollection<ProductNutrient> ProductNutrients { get; set; } = new List<ProductNutrient>();
        public ICollection<ScanHistory> ScanHistories { get; set; } = new List<ScanHistory>();
    }

}
