using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AiReportRepository : EfRepositoryBase<AiReport, Guid, BaseDbContext>, IAiReportRepository
{
    public AiReportRepository(BaseDbContext context) : base(context)
    {
    }
}