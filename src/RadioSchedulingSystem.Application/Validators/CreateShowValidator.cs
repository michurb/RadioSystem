using FluentValidation;
using RadioSchedulingSystem.Application.DTO;

namespace RadioSchedulingSystem.Application.Validators;

public class CreateShowValidator : AbstractValidator<CreateShowDto>
{
    public CreateShowValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        RuleFor(x => x.Presenter)
            .NotEmpty().WithMessage("Presenter is required.");
        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("Start time is required.")
            .GreaterThan(DateTime.UtcNow).WithMessage("Start time must be in the future.");
        RuleFor(x => x.DurationMinutes)
            .GreaterThan(0).WithMessage("Duration must be greater than 0 minutes.");
    }
}