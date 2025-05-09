using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Commands.LayoutTestings.Delete;

public record DeleteLayoutTestingCommand(Guid Id) : ICommand;
