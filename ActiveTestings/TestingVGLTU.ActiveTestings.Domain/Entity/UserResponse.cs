using TestingVGLTU.SharedKernel.ValueObjects.IDs;

namespace TestingVGLTU.ActiveTestings.Domain.Entity;

public class UserResponse : SharedKernel.Entity<UserResponseId>
{
    private UserResponse(UserResponseId id) : base(id) { }
    private UserResponse(
        UserResponseId id,
        QuestionId questionId,
        HistoryId historyId,
        string response,
        bool? isCorrect) : base(id)
    {
        HistoryId = historyId;
        Response = response;
        IsCorrect = isCorrect;
    }

    public HistoryId HistoryId { get; set; } = default!;

    public QuestionId QuestionId { get; set; } = default!;

    public string Response { get; set; } = default!;
    
    public bool? IsCorrect { get; set; }
    
    public static UserResponse Create(
        UserResponseId id,
        HistoryId historyId,
        QuestionId questionId,
        string response,
        bool? isCorrect)
    {
        return new UserResponse(id, questionId, historyId, response, isCorrect);
    }
}
