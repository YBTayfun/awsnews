using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class ReportDto
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }

    public ReportDto( )
    {

    }
    public ReportDto( string title, string link, string description)
    {
        Title = title;
        Link = link;
        Description = description;
    }

    public void DisplayReportInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Link: {Link}");
        Console.WriteLine($"Description: {Description}");
    }
}
