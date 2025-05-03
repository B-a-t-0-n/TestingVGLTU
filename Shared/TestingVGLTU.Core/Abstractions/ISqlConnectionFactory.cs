using System.Data;

namespace TestingVGLTU.Core.Abstractions;

public interface ISqlConnectionFactory
{
    IDbConnection Create();
}