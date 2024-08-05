using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Interfaces.Services;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Services
{
    public class TestingService : ITestingService
    {
        private readonly ITestingRepository _testingRepository;
        private readonly ITypeTestingRepository _typeTestingRepository;

        public TestingService(ITestingRepository testingRepository, ITypeTestingRepository typeTestingRepository)
        {
            _testingRepository = testingRepository;
            _typeTestingRepository = typeTestingRepository;
        }

        public async Task<Testing?> Create(string Name, string type, string outputOfRezult, uint Attempts, int Time, int teacherId)
        {
            var typeTesting = await _typeTestingRepository.GetByName(type);

            if (typeTesting == null)
                throw new Exception("данного типа тестирования не сущевствует");

            return await _testingRepository.Create(Name, typeTesting.Id, outputOfRezult, Attempts, new DateTime(0, 0, 0, 0, Time, 0), teacherId);
        }

        public async Task Update(Testing testing)
        {
            await _testingRepository.Update(testing);
        }
    }
}
