using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class ConditionRule
    {
        public int Id { get; set; }

        [ForeignKey(nameof(MedicalCondition))]
        public int ConditionId { get; set; }
        public MedicalCondition MedicalCondition { get; set; }

        [Required, MaxLength(50)]
        public string RuleType { get; set; } // "ingredient" או "nutrient"

        [Required, MaxLength(100)]
        public string Target { get; set; } // ingredient או nutrient name

        [MaxLength(20)]
        public string Operator { get; set; } // >, <, =, contains

        public float? Threshold { get; set; } // למזונות עם ערך מספרי

        public float Penalty { get; set; }
    }
}
