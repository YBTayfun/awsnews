using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AiReports;

public interface IAiReportsService
{
    Task<AiReport?> GetAsync(
        Expression<Func<AiReport, bool>> predicate,
        Func<IQueryable<AiReport>, IIncludableQueryable<AiReport, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AiReport>?> GetListAsync(
        Expression<Func<AiReport, bool>>? predicate = null,
        Func<IQueryable<AiReport>, IOrderedQueryable<AiReport>>? orderBy = null,
        Func<IQueryable<AiReport>, IIncludableQueryable<AiReport, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AiReport> AddAsync(AiReport aiReport);
    Task<AiReport> UpdateAsync(AiReport aiReport);
    Task<AiReport> DeleteAsync(AiReport aiReport, bool permanent = false);
}
