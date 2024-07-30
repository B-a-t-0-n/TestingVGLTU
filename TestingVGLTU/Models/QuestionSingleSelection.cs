namespace TestingVGLTU.Models
{
    public class QuestionSingleSelection : Question
    {
        public string[] AnswerOptions { get; set; } = null!;
        public string RightAnswer { get; set; } = null!;
    }
}
