using TestingVGLTU.Core.Dtos;

namespace TestingVGLTU.Models.ViewModel;

public class CreateTestingViewModel
{
    public string Name { get; set; } = string.Empty;

    public string TypeTestingId { get; set; } = string.Empty;

    public string OutputOfResult { get; set; } = string.Empty;

    public int Attempts { get; set; }

    public int Time { get; set; }

    public List<TypeTestingDto> TypeTestings { get; set; } = [];

    public List<string> TypesOutputOfResult { get; set; } = [];
}
