using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class MedicalCondition
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Key { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;

        public bool IsCritical { get; set; }

        public ICollection<UserCondition> UserConditions { get; set; } = new List<UserCondition>();
        public ICollection<ConditionRule> ConditionRules { get; set; } = new List<ConditionRule>();
    }
}