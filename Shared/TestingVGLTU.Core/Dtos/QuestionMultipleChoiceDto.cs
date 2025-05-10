namespace TestingVGLTU.Core.Dtos;

public class QuestionMultipleChoiceDto
{
    public Guid Id { get; set; }
    public IEnumerable<string> AnswersOptions { get; set; } = [];
    public IEnumerable<string> CorrectAnswers { get; set; } = [];
}
