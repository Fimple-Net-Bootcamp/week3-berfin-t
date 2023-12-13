namespace PetCareApplication.Data
{
    public class HealthCondition
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public bool IsHealth { get; set; }
        public int PetId { get; set; }
        
    }
}
