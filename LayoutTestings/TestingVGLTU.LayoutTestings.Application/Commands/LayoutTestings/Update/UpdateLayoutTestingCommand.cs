using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.LayoutTestings.Update;

public record UpdateLayoutTestingCommand(
    Guid Id,
    string Title,
    int Attemps,
    Guid TypeTestingId,
    DateTime Time,
    string TypeOutPut) : ICommand;
