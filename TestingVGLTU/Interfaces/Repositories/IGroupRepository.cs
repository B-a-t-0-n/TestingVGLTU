using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Interfaces.Repositories
{
    public interface IGroupRepository
    {
        Task Create(string Name);
        Task Delete(int id);
        Task<List<Group>> Get();
        Task<Group?> GetById(int id);
        Task<Group?> GetByName(string name);
        Task Update(Group group);
    }
}