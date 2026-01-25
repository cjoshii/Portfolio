using FluentValidation;

namespace Portfolio.Application.System;

public class EchoCommandValidator : AbstractValidator<EchoCommand>
{
    public EchoCommandValidator()
    {
        RuleFor(x => x.Message).NotEmpty().WithMessage("Message must not be empty.")
        .MaximumLength(20).WithMessage("Message cannot exceed 20 characters.");
    }
}
