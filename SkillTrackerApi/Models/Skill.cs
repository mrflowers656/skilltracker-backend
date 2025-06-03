namespace SkillTrackerApi.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; } // 1 to 5
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}