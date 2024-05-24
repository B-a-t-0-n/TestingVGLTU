namespace TestingVGLTU.Data.Entities
{
    public class QuestionSingleSelection : Question
    {
        public string[] AnswerOptions { get; set; } = null!;
        public string RightAnswer { get; set; } = null!;
    }
}
