using Application.Features.AiReports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.AiReports.Queries.GetById;

public class GetByIdAiReportQuery : IRequest<GetByIdAiReportResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAiReportQueryHandler : IRequestHandler<GetByIdAiReportQuery, GetByIdAiReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAiReportRepository _aiReportRepository;
        private readonly AiReportBusinessRules _aiReportBusinessRules;

        public GetByIdAiReportQueryHandler(IMapper mapper, IAiReportRepository aiReportRepository, AiReportBusinessRules aiReportBusinessRules)
        {
            _mapper = mapper;
            _aiReportRepository = aiReportRepository;
            _aiReportBusinessRules = aiReportBusinessRules;
        }

        public async Task<GetByIdAiReportResponse> Handle(GetByIdAiReportQuery request, CancellationToken cancellationToken)
        {
            AiReport? aiReport = await _aiReportRepository.GetAsync(predicate: ar => ar.Id == request.Id, cancellationToken: cancellationToken);
            await _aiReportBusinessRules.AiReportShouldExistWhenSelected(aiReport);

            GetByIdAiReportResponse response = _mapper.Map<GetByIdAiReportResponse>(aiReport);
            return response;
        }
    }
}