using FluentValidation;

namespace Application.Features.Reports.Commands.Create;

public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
{
    public CreateReportCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Link).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.AiReport).NotEmpty();
    }
}