using Application.Features.Reports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reports.Queries.GetById;

public class GetByIdReportQuery : IRequest<GetByIdReportResponse>
{
    public Guid Id { get; set; }

    public class GetByIdReportQueryHandler : IRequestHandler<GetByIdReportQuery, GetByIdReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        private readonly ReportBusinessRules _reportBusinessRules;

        public GetByIdReportQueryHandler(IMapper mapper, IReportRepository reportRepository, ReportBusinessRules reportBusinessRules)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
            _reportBusinessRules = reportBusinessRules;
        }

        public async Task<GetByIdReportResponse> Handle(GetByIdReportQuery request, CancellationToken cancellationToken)
        {
            Report? report = await _reportRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _reportBusinessRules.ReportShouldExistWhenSelected(report);

            GetByIdReportResponse response = _mapper.Map<GetByIdReportResponse>(report);
            return response;
        }
    }
}