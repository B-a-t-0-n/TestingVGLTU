namespace TestingVGLTU.Core.Dtos;

public class LayoutTestingDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Attemps { get; set; }
    public Guid TypeTestingId { get; set; }
    public DateTime Time { get; set; }
    public string TypeOutPut { get; set; } = string.Empty;
    public Guid TeacherId { get; set; }
    public DateTime CreatedAt { get; set; }
}
