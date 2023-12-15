using Application.Features.AiReports.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.AiReports.Rules;

public class AiReportBusinessRules : BaseBusinessRules
{
    private readonly IAiReportRepository _aiReportRepository;

    public AiReportBusinessRules(IAiReportRepository aiReportRepository)
    {
        _aiReportRepository = aiReportRepository;
    }

    public Task AiReportShouldExistWhenSelected(AiReport? aiReport)
    {
        if (aiReport == null)
            throw new BusinessException(AiReportsBusinessMessages.AiReportNotExists);
        return Task.CompletedTask;
    }

    public async Task AiReportIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AiReport? aiReport = await _aiReportRepository.GetAsync(
            predicate: ar => ar.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AiReportShouldExistWhenSelected(aiReport);
    }
}