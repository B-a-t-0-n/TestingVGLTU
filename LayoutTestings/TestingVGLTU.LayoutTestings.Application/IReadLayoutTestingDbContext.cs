using TestingVGLTU.LayoutTestings.Domain.Entity;
using TestingVGLTU.LayoutTestings.Domain.Entity.Questions;

namespace TestingVGLTU.LayoutTestings.Application;

public interface IReadLayoutTestingDbContext
{
    IQueryable<LayoutTesting> LayoutTestings { get; }

    IQueryable<Question> Questions { get; }

    IQueryable<QuestionInputNumber> QuestionInputNumbers { get; }

    IQueryable<QuestionInputText> QuestionInputTexts { get; }

    IQueryable<QuestionSingleSelection> QuestionSingleSelections { get; }

    IQueryable<QuestionMultipleChoice> QuestionMultipleChoices { get; }

    IQueryable<TypeTesting> TypeTestings { get; }
}
