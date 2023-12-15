using Application.Features.AiReports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AiReports.Commands.Create;

public class CreateAiReportCommand : IRequest<CreatedAiReportResponse>
{
    public Guid ReportId { get; set; }
    public string SideA { get; set; }
    public string SideB { get; set; }
    public int CasualtiesA { get; set; }
    public int CasualtiesB { get; set; }
    public int CasualtiesAll { get; set; }
    public int CasualtiesCivilian { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public DateTime ReportDate { get; set; }
    public string Source { get; set; }

    public class CreateAiReportCommandHandler : IRequestHandler<CreateAiReportCommand, CreatedAiReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAiReportRepository _aiReportRepository;
        private readonly AiReportBusinessRules _aiReportBusinessRules;

        public CreateAiReportCommandHandler(IMapper mapper, IAiReportRepository aiReportRepository,
                                         AiReportBusinessRules aiReportBusinessRules)
        {
            _mapper = mapper;
            _aiReportRepository = aiReportRepository;
            _aiReportBusinessRules = aiReportBusinessRules;
        }

        public async Task<CreatedAiReportResponse> Handle(CreateAiReportCommand request, CancellationToken cancellationToken)
        {
            AiReport aiReport = _mapper.Map<AiReport>(request);

            await _aiReportRepository.AddAsync(aiReport);

            CreatedAiReportResponse response = _mapper.Map<CreatedAiReportResponse>(aiReport);
            return response;
        }
    }
}