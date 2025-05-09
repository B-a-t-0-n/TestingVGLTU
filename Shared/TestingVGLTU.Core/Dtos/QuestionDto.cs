namespace TestingVGLTU.Core.Dtos;

public class QuestionDto
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public int SerialNumber { get; set; }
    public int Scores { get; set; }

    public QuestionInputNumberDto? QuestionInputNumber { get; set; }
    public QuestionInputTextDto? QuestionInputText { get; set; }
    public QuestionSingleSelectionDto? QuestionInputSingleSelection { get; set; }
    public QuestionMultipleChoiceDto? QuestionInputMultipleChoice { get; set; }

}
