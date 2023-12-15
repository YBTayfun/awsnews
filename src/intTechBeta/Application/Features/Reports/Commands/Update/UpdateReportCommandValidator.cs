using FluentValidation;

namespace Application.Features.Reports.Commands.Update;

public class UpdateReportCommandValidator : AbstractValidator<UpdateReportCommand>
{
    public UpdateReportCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Link).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.AiReport).NotEmpty();
    }
}