namespace Repository.Entities
{
    public class UserCondition
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int ConditionId { get; set; }
        public MedicalCondition MedicalCondition { get; set; } = null!;
    }
}