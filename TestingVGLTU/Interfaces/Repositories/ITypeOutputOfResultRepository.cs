using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface ITypeOutputOfResultRepository
    {
        Task Create(string Name);
        Task Delete(int id);
        Task<List<TypeOutputOfResult>> Get();
        Task<TypeOutputOfResult?> GetById(int id);
        Task<TypeOutputOfResult?> GetByName(string name);
        Task Update(TypeOutputOfResult type);
    }
}