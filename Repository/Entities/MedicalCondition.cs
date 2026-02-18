using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class MedicalCondition
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Key { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public bool IsCritical { get; set; }

        public ICollection<UserCondition> UserConditions { get; set; } = new List<UserCondition>();
        public ICollection<ConditionRule> ConditionRules { get; set; } = new List<ConditionRule>();
    }

}
