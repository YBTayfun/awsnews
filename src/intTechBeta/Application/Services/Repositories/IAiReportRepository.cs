using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAiReportRepository : IAsyncRepository<AiReport, Guid>, IRepository<AiReport, Guid>
{
}