using FluentValidation;

namespace Application.Features.AiReports.Commands.Delete;

public class DeleteAiReportCommandValidator : AbstractValidator<DeleteAiReportCommand>
{
    public DeleteAiReportCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}