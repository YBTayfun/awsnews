using Application.Features.AiReports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AiReports.Commands.Update;

public class UpdateAiReportCommand : IRequest<UpdatedAiReportResponse>
{
    public Guid Id { get; set; }
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

    public class UpdateAiReportCommandHandler : IRequestHandler<UpdateAiReportCommand, UpdatedAiReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAiReportRepository _aiReportRepository;
        private readonly AiReportBusinessRules _aiReportBusinessRules;

        public UpdateAiReportCommandHandler(IMapper mapper, IAiReportRepository aiReportRepository,
                                         AiReportBusinessRules aiReportBusinessRules)
        {
            _mapper = mapper;
            _aiReportRepository = aiReportRepository;
            _aiReportBusinessRules = aiReportBusinessRules;
        }

        public async Task<UpdatedAiReportResponse> Handle(UpdateAiReportCommand request, CancellationToken cancellationToken)
        {
            AiReport? aiReport = await _aiReportRepository.GetAsync(predicate: ar => ar.Id == request.Id, cancellationToken: cancellationToken);
            await _aiReportBusinessRules.AiReportShouldExistWhenSelected(aiReport);
            aiReport = _mapper.Map(request, aiReport);

            await _aiReportRepository.UpdateAsync(aiReport!);

            UpdatedAiReportResponse response = _mapper.Map<UpdatedAiReportResponse>(aiReport);
            return response;
        }
    }
}