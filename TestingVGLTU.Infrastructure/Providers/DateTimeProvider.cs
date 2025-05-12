using TestingVGLTU.Core.Providers;

namespace TestingVGLTU.Infrastructure.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
