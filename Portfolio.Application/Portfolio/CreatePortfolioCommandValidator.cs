using FluentValidation;

namespace Portfolio.Application.Portfolio;

public class CreatePortfolioCommandValidator : AbstractValidator<CreatePortfolioCommand>
{
    public CreatePortfolioCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Portfolio name must not be empty.")
            .MaximumLength(100).WithMessage("Portfolio name must not exceed 100 characters.");

        RuleFor(command => command.Description)
            .MaximumLength(200).WithMessage("Portfolio description must not exceed 500 characters.");
    }
}
