using Repository.Entities;
using System.ComponentModel.DataAnnotations;

namespace HealthScanner.DTOs
{
    // DTO להחזרה (GET)
    public class ProductDto
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Barcode { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = null!;

        [MaxLength(150)]
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; internal set; }
    }

    // DTO ליצירה (POST)
    public class ProductCreateDto
    {
        [MaxLength(50)]
        public string? Barcode { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; } = null!;
        [MaxLength(150)]
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }

    // DTO לעדכון (PUT)
    public class ProductUpdateDto
    {
        [MaxLength(50)]
        public string? Barcode { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; } = null!;
        [MaxLength(150)]
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }

}



