using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.LayoutTestings.Create;

public record CreateLayoutTestingCommand(
    string Title,
    int Attemps,
    Guid TypeTestingId,
    DateTime Time,
    Guid TeacherId,
    string TypeOutPut) : ICommand;
