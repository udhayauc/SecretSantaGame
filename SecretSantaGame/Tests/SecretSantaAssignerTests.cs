using System.Collections.Generic;
using Xunit;
using SecretSantaGame.Models;
using SecretSantaGame.Services;

public class SecretSantaAssignerTests
{
    [Fact]
    public void AssignSecretSantas_ShouldAssignCorrectly()
    {
        var employees = new List<Employee>
        {
            new Employee { Name = "Alice", Email = "alice@example.com" },
            new Employee { Name = "Bob", Email = "bob@example.com" },
            new Employee { Name = "Charlie", Email = "charlie@example.com" }
        };

        var lastYearAssignments = new Dictionary<string, string>();

        var assigner = new SecretSantaAssigner();
        var assignments = assigner.AssignSecretSantas(employees, lastYearAssignments);

        Assert.Equal(3, assignments.Count);
        Assert.DoesNotContain(assignments, a => a.Santa.Email == a.SecretChild.Email);
    }
}
