using Core.Persistence.Repositories;
using System;

public class AiReportDto 
{
    public Guid ReportId { get; }
    public string SideA { get; }
    public string SideB { get; }
    public int CasualtiesA { get; }
    public int CasualtiesB { get; }
    public int CasualtiesAll { get; }
    public int CasualtiesCivilian { get; }
    public string Country { get; }
    public string City { get; }
    public string Region { get; }
    public string Source { get; }


    public AiReportDto()
    {
        
    }
    public AiReportDto(Guid reportId, string sideA, string sideB, int casualtiesA, int casualtiesB,
                    int casualtiesAll, int casualtiesCivilian, string country, string city,
                    string region, string source)
    {
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
