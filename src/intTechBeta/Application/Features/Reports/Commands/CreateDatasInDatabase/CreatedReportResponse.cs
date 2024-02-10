using Core.Application.Responses;

namespace Application.Features.Reports.Commands.Create;

public class CreatedDatasInDatabaseResponse : IResponse
{
    public string Message { get; set; }
}