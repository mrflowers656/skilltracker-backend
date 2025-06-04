using SkillTrackerApi.Models;
using Microsoft.EntityFrameworkCore;
using SkillTrackerApi.Data;
using Xunit;

public class SkillTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public void AddSkill_SavesToDatabase()
    {
        var context = GetDbContext();

        var skill = new Skill
        {
            Name = "Unit Testing",
            Level = 5,
            Category = "Backend"
        };

        context.Skills.Add(skill);
        context.SaveChanges();

        Assert.Equal(1, context.Skills.Count());
        Assert.Equal("Unit Testing", context.Skills.First().Name);
    }

    [Fact]
    public void DeleteSkill_RemovesSkillFromDatabase()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using (var context = new AppDbContext(options))
        {
            var skill = new Skill
            {
                Name = "To Be Deleted",
                Level = 3,
                Category = "Test"
            };

            context.Skills.Add(skill);
            context.SaveChanges();

            context.Skills.Remove(skill);
            context.SaveChanges();
        }

        // Assert
        using (var context = new AppDbContext(options))
        {
            Assert.Empty(context.Skills);
        }
    }

}
