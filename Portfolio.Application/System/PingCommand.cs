using Portfolio.Application.Abstractions.Messaging;

namespace Portfolio.Application.System;

public sealed record PingCommand() : ICommand<string>;
