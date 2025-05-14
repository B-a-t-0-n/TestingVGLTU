using TestingVGLTU.Core.Dtos;

namespace TestingVGLTU.Models.ViewModel;

public class TestingEditorViewModel
{
    public Guid LayoutTestingId { get; set; }

    public CreateTestingViewModel CreateTestingViewModel { get; set; } = new();

    public List<QuestionDto> Questions { get; set; } = [];
}
