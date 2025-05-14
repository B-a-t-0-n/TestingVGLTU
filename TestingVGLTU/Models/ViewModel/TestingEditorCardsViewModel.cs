using TestingVGLTU.Core.Dtos;

namespace TestingVGLTU.Models.ViewModel;

public class TestingEditorCardsViewModel
{
    public string TeacherName { get; set; } = string.Empty;
    public List<LayoutTestingDto> LayoutTestings { get; set; } = [];
    public List<TypeTestingDto> TypeTestings { get; set; } = [];
}
