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

        public async Task<Testing?> CreateAsync(string Name, string type, string outputOfRezult, uint Attempts, int Time, int teacherId)
        {
            var typeTesting = await _typeTestingRepository.GetByName(type);

            if (typeTesting == null)
                throw new Exception("данного типа тестирования не сущевствует");

            var typeOutputOfRezult = await _typeTestingRepository.GetByName(type);

            if (typeOutputOfRezult == null)
                throw new Exception("данного типа вывода результата не сущевствует");

            var hours = Time / 60;
            var minutes = Time % 60;

            var timeOnly = new TimeOnly(hours, minutes);

            return await _testingRepository.Create(Name, type, outputOfRezult, Attempts, timeOnly, teacherId);
        }

        public async Task Update(Testing testing)
        {
            await _testingRepository.Update(testing);
        }

        public async Task Delete(int id)
        {
            await _testingRepository.Delete(id);
        }

        public async Task<List<Testing>> GetByTeacherId(int id) => await _testingRepository.GetByTeacherId(id);

        public async Task<List<TypeTesting>> GetTypeTestingAsync() => await _typeTestingRepository.Get();

        public async Task<List<TypeOutputOfResult>> TypeOutputOfResultsAsync() => await _typeOutputOfResultRepository.Get();
    }
}
