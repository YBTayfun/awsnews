using Core.Application.Responses;

namespace Application.Features.AiReports.Commands.Update;

public class UpdatedAiReportResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ReportId { get; set; }
    public string SideA { get; set; }
    public string SideB { get; set; }
    public int CasualtiesA { get; set; }
    public int CasualtiesB { get; set; }
    public int CasualtiesAll { get; set; }
    public int CasualtiesCivilian { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public DateTime ReportDate { get; set; }
    public string Source { get; set; }
}