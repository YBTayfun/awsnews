using Core.Persistence.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Report : Entity<Guid>
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }

    public AiReport AiReport { get; set; }

    public Report()
    {

    }

public Report(string title, string link, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Link = link;
        Description = description;
    }

    public Report(Guid id, string title, string link, string description)
    {
        Id = id;
        Title = title;
        Link = link;
        Description = description;
    }

    public void DisplayReportInfo()
    {
        Console.WriteLine($"Report ID: {Id}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Link: {Link}");
        Console.WriteLine($"Description: {Description}");
    }
}
