namespace PetCareApplication.Data
{
    public class Pet
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string Kind { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int UserId { get; set; }
        //public User User { get; set; }
        public List<HealthCondition> HealthConditions { get; set; }
        public List<Activities> Activities { get; set; }
        public List<Food> Foods { get; set; }
    }
}
