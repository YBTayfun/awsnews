using Core.Application.Responses;

namespace Application.Features.Reports.Commands.Create;

public class CreatedReportResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
    public AiReport AiReport { get; set; }
}