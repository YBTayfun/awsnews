using Core.Application.Responses;

namespace Application.Features.AiReports.Commands.Delete;

public class DeletedAiReportResponse : IResponse
{
    public Guid Id { get; set; }
}