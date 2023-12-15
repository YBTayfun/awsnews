using Application.Features.AiReports.Constants;
using Application.Features.AiReports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AiReports.Commands.Delete;

public class DeleteAiReportCommand : IRequest<DeletedAiReportResponse>
{
    public Guid Id { get; set; }

    public class DeleteAiReportCommandHandler : IRequestHandler<DeleteAiReportCommand, DeletedAiReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAiReportRepository _aiReportRepository;
        private readonly AiReportBusinessRules _aiReportBusinessRules;

        public DeleteAiReportCommandHandler(IMapper mapper, IAiReportRepository aiReportRepository,
                                         AiReportBusinessRules aiReportBusinessRules)
        {
            _mapper = mapper;
            _aiReportRepository = aiReportRepository;
            _aiReportBusinessRules = aiReportBusinessRules;
        }

        public async Task<DeletedAiReportResponse> Handle(DeleteAiReportCommand request, CancellationToken cancellationToken)
        {
            AiReport? aiReport = await _aiReportRepository.GetAsync(predicate: ar => ar.Id == request.Id, cancellationToken: cancellationToken);
            await _aiReportBusinessRules.AiReportShouldExistWhenSelected(aiReport);

            await _aiReportRepository.DeleteAsync(aiReport!);

            DeletedAiReportResponse response = _mapper.Map<DeletedAiReportResponse>(aiReport);
            return response;
        }
    }
}