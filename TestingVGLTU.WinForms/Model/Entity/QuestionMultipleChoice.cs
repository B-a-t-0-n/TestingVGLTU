namespace TestingVGLTU.Models.Entity
{
    public class QuestionMultipleChoice : Question
    {
        public string AnswerOptions { get; set; } = null!;
        public string CorrectAnswers { get; set; } = null!;
    }
}
