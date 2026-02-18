using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class UserCondition
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(MedicalCondition))]
        public int ConditionId { get; set; }
        public MedicalCondition MedicalCondition { get; set; }
    }
}
