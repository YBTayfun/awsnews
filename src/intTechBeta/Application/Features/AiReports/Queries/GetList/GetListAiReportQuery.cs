using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.AiReports.Queries.GetList;

public class GetListAiReportQuery : IRequest<GetListResponse<GetListAiReportListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAiReportQueryHandler : IRequestHandler<GetListAiReportQuery, GetListResponse<GetListAiReportListItemDto>>
    {
        private readonly IAiReportRepository _aiReportRepository;
        private readonly IMapper _mapper;

        public GetListAiReportQueryHandler(IAiReportRepository aiReportRepository, IMapper mapper)
        {
            _aiReportRepository = aiReportRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAiReportListItemDto>> Handle(GetListAiReportQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AiReport> aiReports = await _aiReportRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAiReportListItemDto> response = _mapper.Map<GetListResponse<GetListAiReportListItemDto>>(aiReports);
            return response;
        }
    }
}