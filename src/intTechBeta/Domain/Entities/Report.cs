using Core.Persistence.Repositories;
public class Report : Entity<Guid>
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
    public DateTime ReportDate { get; set; }

    public virtual AiReport? AiReport { get; set; }

    public Report()
    {
        // Varsayılan kurucu metot
    }

    public Report(string title, string link, string description, DateTime reportDate)
    {
        Id = Guid.NewGuid();
        Title = title;
        Link = link;
        Description = description;
        ReportDate = reportDate; // Dışarıdan alınan tarihi kullanıcı tanımlıyor
    }

    public Report(Guid id, string title, string link, string description, DateTime reportDate)
    {
        Id = id;
        Title = title;
        Link = link;
        Description = description;
        ReportDate = reportDate; // Dışarıdan alınan tarihi kullanıcı tanımlıyor
    }

    public void DisplayReportInfo(Guid id, string title, string link, string description)
    {
        Console.WriteLine($"Rapor ID: {id}");
        Console.WriteLine($"Başlık: {title}");
        Console.WriteLine($"Bağlantı: {link}");
        Console.WriteLine($"Açıklama: {description}");
    }
}
