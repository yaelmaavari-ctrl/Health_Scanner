using System.ComponentModel.DataAnnotations;


namespace HealthScanner.DTOs
{
    // DTO להחזרה (GET)
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // DTO ליצירה (POST)
    public class IngredientCreateDto
    {
        [Required, MaxLength(150)]
        public string Name { get; set; } = null!;
    }

    // DTO לעדכון (PUT)
    public class IngredientUpdateDto
    {
        [Required, MaxLength(150)]
        public string Name { get; set; } = null!;
    }
}
