using System.ComponentModel.DataAnnotations;

namespace HealthScanner.DTOs
{
    // DTO להחזרה (GET)
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;  
        public bool StrictMode { get; set; }
        public string Password { get; internal set; }
    }

    // DTO ליצירה (POST)
    public class UserCreateDto
    {  
        [Required, MaxLength(100)]
        public string FullName { get; set; } = null!;
        [Required, MaxLength(150)]
        public string Email { get; set; } = null!;
        [Required, MinLength(6)]
        public string Password { get; set; } = null!; // סיסמה נדרשת ליצירה
        public bool StrictMode { get; set; }
    }

    // DTO לעדכון (PUT)
    public class UserUpdateDto
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; } = null!;
        [Required, MaxLength(150)]
        public string Email { get; set; } = null!;

        [MinLength(6)]
       public string? Password { get; set; } // סיסמה לא חובה לעדכון
        public bool StrictMode { get; set; }
    }
}

