using TestingVGLTU.Core.Abstractions;

namespace TestingVGLTU.LayoutTestings.Application.Queries.Questions.GetQuestionsById;

public record GetQuestionsByIdQuery(Guid Id) : IQuery;
