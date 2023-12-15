using Application.Features.Reports.Constants;
using Application.Features.Reports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reports.Commands.Delete;

public class DeleteReportCommand : IRequest<DeletedReportResponse>
{
    public Guid Id { get; set; }

    public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand, DeletedReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        private readonly ReportBusinessRules _reportBusinessRules;

        public DeleteReportCommandHandler(IMapper mapper, IReportRepository reportRepository,
                                         ReportBusinessRules reportBusinessRules)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
            _reportBusinessRules = reportBusinessRules;
        }

        public async Task<DeletedReportResponse> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
        {
            Report? report = await _reportRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _reportBusinessRules.ReportShouldExistWhenSelected(report);

            await _reportRepository.DeleteAsync(report!);

            DeletedReportResponse response = _mapper.Map<DeletedReportResponse>(report);
            return response;
        }
    }
}