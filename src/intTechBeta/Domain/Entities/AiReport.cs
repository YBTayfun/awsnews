using Core.Persistence.Repositories;
using System;

public class AiReport : Entity<Guid>
{
    public Guid ReportId { get; set;}
    public string SideA { get; set;}
    public string SideB { get; set;}
    public int CasualtiesA { get; set;}
    public int CasualtiesB { get; set;}
    public int CasualtiesAll { get; set;}
    public int CasualtiesCivilian { get; set;}
    public string Country { get; set;}
    public string City { get; set;}
    public string Region { get; set;}
    public string Source { get; set;}

    public virtual Report? Report { get; set; }

    public AiReport()
    {
        
    }
    public AiReport(Guid reportId, string sideA, string sideB, int casualtiesA, int casualtiesB,
                    int casualtiesAll, int casualtiesCivilian, string country, string city,
                    string region, string source)
    {
        Id = Guid.NewGuid();
        ReportId = reportId;
        SideA = sideA;
        SideB = sideB;
        CasualtiesA = casualtiesA;
        CasualtiesB = casualtiesB;
        CasualtiesAll = casualtiesAll;
        CasualtiesCivilian = casualtiesCivilian;
        Country = country;
        City = city;
        Region = region;
        Source = source;
    }

    public AiReport(Guid id, Guid reportId, string sideA, string sideB, int casualtiesA, int casualtiesB,
                    int casualtiesAll, int casualtiesCivilian, string country, string city,
                    string region, string source)
    {
        Id = id;
        ReportId = reportId;
        SideA = sideA;
        SideB = sideB;
        CasualtiesA = casualtiesA;
        CasualtiesB = casualtiesB;
        CasualtiesAll = casualtiesAll;
        CasualtiesCivilian = casualtiesCivilian;
        Country = country;
        City = city;
        Region = region;
        Source = source;
    }

    public void DisplayAiReportInfo()
    {
        Console.WriteLine($"AiReport ID: {Id}");
        Console.WriteLine($"Report ID: {ReportId}");
        Console.WriteLine($"Side A: {SideA}");
        Console.WriteLine($"Side B: {SideB}");
        Console.WriteLine($"Casualties A: {CasualtiesA}");
        Console.WriteLine($"Casualties B: {CasualtiesB}");
        Console.WriteLine($"Casualties All: {CasualtiesAll}");
        Console.WriteLine($"Casualties Civilian: {CasualtiesCivilian}");
        Console.WriteLine($"Country: {Country}");
        Console.WriteLine($"City: {City}");
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Source: {Source}");
    }
}
