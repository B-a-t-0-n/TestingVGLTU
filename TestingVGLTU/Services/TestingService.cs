using TestingVGLTU.Data.Repositories;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Interfaces.Services;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Services
{
    public class TestingService : ITestingService
    {
        private readonly ITestingRepository _testingRepository;
        private readonly ITypeTestingRepository _typeTestingRepository;
        private readonly ITypeOutputOfResultRepository _typeOutputOfResultRepository;

        public TestingService(ITestingRepository testingRepository, ITypeTestingRepository typeTestingRepository,
            ITypeOutputOfResultRepository typeOutputOfResultRepository)
        {
            _testingRepository = testingRepository;
            _typeTestingRepository = typeTestingRepository;
            _typeOutputOfResultRepository = typeOutputOfResultRepository;
        }

        public async Task<Testing?> Create(string Name, string type, string outputOfRezult, uint Attempts, int Time, int teacherId)
        {
            var typeTesting = await _typeTestingRepository.GetByName(type);

            if (typeTesting == null)
                throw new Exception("данного типа тестирования не сущевствует");

            var typeOutputOfRezult = await _typeTestingRepository.GetByName(type);

            if (typeOutputOfRezult == null)
                throw new Exception("данного типа вывода результата не сущевствует");

            return await _testingRepository.Create(Name, type, outputOfRezult, Attempts, new DateTime(0, 0, 0, 0, Time, 0), teacherId);
        }

        public async Task Update(Testing testing)
        {
            await _testingRepository.Update(testing);
        }
    }
}
