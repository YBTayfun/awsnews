using Application.Features.Reports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Reports.Commands.Update;

public class UpdateReportCommand : IRequest<UpdatedReportResponse>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
    public AiReport AiReport { get; set; }

    public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand, UpdatedReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        private readonly ReportBusinessRules _reportBusinessRules;

        public UpdateReportCommandHandler(IMapper mapper, IReportRepository reportRepository,
                                         ReportBusinessRules reportBusinessRules)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
            _reportBusinessRules = reportBusinessRules;
        }

        public async Task<UpdatedReportResponse> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
        {
            Report? report = await _reportRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _reportBusinessRules.ReportShouldExistWhenSelected(report);
            report = _mapper.Map(request, report);

            await _reportRepository.UpdateAsync(report!);

            UpdatedReportResponse response = _mapper.Map<UpdatedReportResponse>(report);
            return response;
        }
    }
}