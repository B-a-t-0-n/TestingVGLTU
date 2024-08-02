using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface ITypeTestingRepository
    {
        Task Create(string Name);
        Task Delete(int id);
        Task<List<TypeTesting>> Get();
        Task<TypeTesting?> GetById(int id);
        Task<TypeTesting?> GetByName(string name);
        Task Update(TypeTesting type);
    }
}