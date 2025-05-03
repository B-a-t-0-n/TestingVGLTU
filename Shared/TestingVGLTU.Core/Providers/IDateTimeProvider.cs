namespace TestingVGLTU.Core.Providers;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}
