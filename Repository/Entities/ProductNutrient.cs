using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class ProductNutrient
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required, MaxLength(100)]
        public string NutrientName { get; set; } = null!;

        public float Value { get; set; }
    }
}