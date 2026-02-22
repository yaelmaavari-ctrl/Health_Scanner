using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class ConditionRule
    {
        public int Id { get; set; }

        public int ConditionId { get; set; }
        public MedicalCondition MedicalCondition { get; set; } = null!;

        [Required, MaxLength(50)]
        public string RuleType { get; set; } = null!; // "ingredient" או "nutrient"

        [Required, MaxLength(100)]
        public string Target { get; set; } = null!; // ingredient או nutrient name

        [MaxLength(20)]
        public string? Operator { get; set; } // >, <, =, contains

        public float? Threshold { get; set; }

        public float Penalty { get; set; }
    }
}