using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class ScanHistory
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public float FinalScore { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = null!; // safe, warning, danger

        public DateTime ScanDate { get; set; } = DateTime.UtcNow;
    }
}