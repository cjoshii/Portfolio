using FluentValidation;

namespace Portfolio.Application.System;

public class EchoCommandValidator : AbstractValidator<EchoCommand>
{
    public EchoCommandValidator()
    {
        RuleFor(x => x.Arg).NotEmpty().MaximumLength(100).MinimumLength(1).NotNull();
    }
}
