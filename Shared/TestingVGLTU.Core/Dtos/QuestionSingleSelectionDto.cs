namespace TestingVGLTU.Core.Dtos;

public class QuestionSingleSelectionDto
{
    public Guid Id { get; set; }
    public IEnumerable<string> AnswersOptions { get; set; } = [];
    public string RightAnswer { get; set; } = string.Empty;
}
