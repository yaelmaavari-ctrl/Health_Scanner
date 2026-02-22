using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = null!;

        public ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();
    }
}