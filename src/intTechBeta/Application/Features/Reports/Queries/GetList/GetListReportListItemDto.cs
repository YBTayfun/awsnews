using Core.Application.Dtos;

namespace Application.Features.Reports.Queries.GetList;

public class GetListReportListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
    public AiReport AiReport { get; set; }
}