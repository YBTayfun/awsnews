using Core.Persistence.Repositories;

public class AiReport : Entity<Guid>
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
    public DateTime ReportDate { get; }
    public string Source { get; }

    public AiReport(Guid reportId, string sideA, string sideB, int casualtiesA, int casualtiesB,
                    int casualtiesAll, int casualtiesCivilian, string country, string city,
                    string region, DateTime reportDate, string source)
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
        ReportDate = reportDate;

        Source = source;
    }
    public AiReport(Guid id, Guid reportId, string sideA, string sideB, int casualtiesA, int casualtiesB,
                int casualtiesAll, int casualtiesCivilian, string country, string city,
                string region, DateTime reportDate, string source)
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
        ReportDate = reportDate;
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
        Console.WriteLine($"Report Date: {ReportDate}");
        Console.WriteLine($"Source: {Source}");
    }
}