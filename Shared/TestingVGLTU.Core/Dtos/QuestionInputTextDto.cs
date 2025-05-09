namespace TestingVGLTU.Core.Dtos;

public class QuestionInputTextDto
{
    public Guid Id { get; set; }
    public IEnumerable<string> CorrectAnswers { get; set; } = [];
}
