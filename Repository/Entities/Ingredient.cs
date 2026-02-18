using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        public ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();
    }
}
