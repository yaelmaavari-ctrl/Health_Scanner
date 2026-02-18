using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, MaxLength(150)]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string PasswordHash { get; set; }

        public bool StrictMode { get; set; }

        public ICollection<UserCondition> UserConditions { get; set; } = new List<UserCondition>();
        public ICollection<ScanHistory> ScanHistories { get; set; } = new List<ScanHistory>();
    }

}
