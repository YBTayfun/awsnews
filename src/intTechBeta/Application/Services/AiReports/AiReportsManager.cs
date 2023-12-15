using Application.Features.AiReports.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AiReports;

public class AiReportsManager : IAiReportsService
{
    private readonly IAiReportRepository _aiReportRepository;
    private readonly AiReportBusinessRules _aiReportBusinessRules;

    public AiReportsManager(IAiReportRepository aiReportRepository, AiReportBusinessRules aiReportBusinessRules)
    {
        _aiReportRepository = aiReportRepository;
        _aiReportBusinessRules = aiReportBusinessRules;
    }

    public async Task<AiReport?> GetAsync(
        Expression<Func<AiReport, bool>> predicate,
        Func<IQueryable<AiReport>, IIncludableQueryable<AiReport, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AiReport? aiReport = await _aiReportRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return aiReport;
    }

    public async Task<IPaginate<AiReport>?> GetListAsync(
        Expression<Func<AiReport, bool>>? predicate = null,
        Func<IQueryable<AiReport>, IOrderedQueryable<AiReport>>? orderBy = null,
        Func<IQueryable<AiReport>, IIncludableQueryable<AiReport, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AiReport> aiReportList = await _aiReportRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return aiReportList;
    }

    public async Task<AiReport> AddAsync(AiReport aiReport)
    {
        AiReport addedAiReport = await _aiReportRepository.AddAsync(aiReport);

        return addedAiReport;
    }

    public async Task<AiReport> UpdateAsync(AiReport aiReport)
    {
        AiReport updatedAiReport = await _aiReportRepository.UpdateAsync(aiReport);

        return updatedAiReport;
    }

    public async Task<AiReport> DeleteAsync(AiReport aiReport, bool permanent = false)
    {
        AiReport deletedAiReport = await _aiReportRepository.DeleteAsync(aiReport);

        return deletedAiReport;
    }
}
