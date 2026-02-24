namespace HealthScanner.DTOs
{
    // DTO להחזרה (GET)
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // DTO ליצירה (POST)
    public class CategoryCreateDto
    {
        public string Name { get; set; }
    }

    // DTO לעדכון (PUT)
    public class CategoryUpdateDto
    {
        public string Name { get; set; }
    }
}