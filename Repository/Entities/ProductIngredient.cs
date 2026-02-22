using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class ProductIngredient
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;
    }
}