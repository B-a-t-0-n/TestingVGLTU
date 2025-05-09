namespace TestingVGLTU.Core.Dtos;

public class QuestionInputNumberDto
{
    public Guid Id { get; set; }
    public IEnumerable<string> CorrectAnswers { get; set; } = [];
}
