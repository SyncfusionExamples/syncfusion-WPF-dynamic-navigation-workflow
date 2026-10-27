using WizardApp.Models;

namespace WizardApp.Services;

/// <summary>Generates the hierarchical sample data for the tree.</summary>
public static class SampleData
{
    /// <summary>Builds Departments → Department → Team → Employee.</summary>
    public static TreeNodeModel CreateOrganization()
    {
        var data = new (string Dept, (string Team, string[] People)[] Teams)[]
        {
            ("Sales", new[] { ("Inside Sales", new[] { "Alice Moore", "Brian Lee", "Chloe Diaz" }),
                              ("Field Sales", new[] { "Daniel Kim", "Elena Rossi" }),
                              ("Key Accounts", new[] { "Farid Khan", "Grace Hall" }) }),
            ("Marketing", new[] { ("Content", new[] { "Hannah Park", "Ian Wood" }),
                                  ("Digital", new[] { "Julia Chen", "Kevin Brown", "Laura Evans" }),
                                  ("Events", new[] { "Marco Silva" }) }),
            ("Support", new[] { ("Tier 1", new[] { "Nina Patel", "Oscar Reed", "Paula Gomez" }),
                                ("Tier 2", new[] { "Quinn Adams", "Rita Singh" }),
                                ("Customer Success", new[] { "Sam Turner", "Tara Lopez" }) }),
            ("Engineering", new[] { ("Platform", new[] { "Uma Shah", "Victor Hugo" }),
                                    ("QA", new[] { "Wendy Fox", "Xavier Cole" }) }),
        };

        var root = new TreeNodeModel { Name = "Departments", Glyph = "\uE80F", Description = $"{data.Length} departments" };
        foreach (var (dept, teams) in data)
        {
            var d = new TreeNodeModel { Name = dept, Glyph = "\uE716", Description = $"{teams.Length} teams" };
            foreach (var (team, people) in teams)
            {
                var t = new TreeNodeModel { Name = team, Glyph = "\uE902", Description = $"{people.Length} members" };
                foreach (var p in people)
                    t.Children.Add(new TreeNodeModel { Name = p, Glyph = "\uE77B", Description = "Employee" });
                d.Children.Add(t);
            }
            root.Children.Add(d);
        }
        return root;
    }
}
