using Portfolio.Application.Abstractions.Messaging;

namespace Portfolio.Application.System;

public sealed record EchoCommand(string Message) : ICommand<EchoResponse>;
public sealed record EchoResponse(string Echo);
