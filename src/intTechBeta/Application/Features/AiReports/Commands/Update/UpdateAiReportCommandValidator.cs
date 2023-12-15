using FluentValidation;

namespace Application.Features.AiReports.Commands.Update;

public class UpdateAiReportCommandValidator : AbstractValidator<UpdateAiReportCommand>
{
    public UpdateAiReportCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ReportId).NotEmpty();
        RuleFor(c => c.SideA).NotEmpty();
        RuleFor(c => c.SideB).NotEmpty();
        RuleFor(c => c.CasualtiesA).NotEmpty();
        RuleFor(c => c.CasualtiesB).NotEmpty();
        RuleFor(c => c.CasualtiesAll).NotEmpty();
        RuleFor(c => c.CasualtiesCivilian).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.Region).NotEmpty();
        RuleFor(c => c.ReportDate).NotEmpty();
        RuleFor(c => c.Source).NotEmpty();
    }
}