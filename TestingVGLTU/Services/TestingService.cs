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
        private readonly IQuestionInputNumberRepository _questionInputNumberRepository;
        private readonly IQuestionInputTextRepository _questionInputTextRepository;
        private readonly IQuestionSingleSelectionRepository _questionSingleSelectionRepository;
        private readonly IQuestionMultipleChoiceRepository _questionMultipleChoiceRepository;

        public TestingService(ITestingRepository testingRepository, ITypeTestingRepository typeTestingRepository,
            ITypeOutputOfResultRepository typeOutputOfResultRepository, IQuestionInputNumberRepository questionInputNumberRepository,
            IQuestionInputTextRepository questionInputTextRepository, IQuestionMultipleChoiceRepository questionMultipleChoiceRepository, 
            IQuestionSingleSelectionRepository questionSingleSelectionRepository)
        {
            _testingRepository = testingRepository;
            _typeTestingRepository = typeTestingRepository;
            _typeOutputOfResultRepository = typeOutputOfResultRepository;
            _questionInputNumberRepository = questionInputNumberRepository;
            _questionInputTextRepository = questionInputTextRepository; 
            _questionMultipleChoiceRepository = questionMultipleChoiceRepository;
            _questionSingleSelectionRepository = questionSingleSelectionRepository;
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

        public async Task<Testing?> GetByTestingIdFullData(int id) => await _testingRepository.GetFullData(id);

        public async Task<List<Testing>> GetByTeacherId(int id) => await _testingRepository.GetByTeacherId(id);

        public async Task<List<TypeTesting>> GetTypeTestingAsync() => await _typeTestingRepository.Get();

        public async Task<List<TypeOutputOfResult>> TypeOutputOfResultsAsync() => await _typeOutputOfResultRepository.Get();

        public async Task<Question?> GetQuestionByIdFullData(int id)
        {
            var questionIN = await _questionInputNumberRepository.GetById(id);

            if (questionIN != null)
                return questionIN;

            var questionIT = await _questionInputTextRepository.GetById(id);

            if (questionIT != null)
                return questionIT;

            var questionMC = await _questionMultipleChoiceRepository.GetById(id);

            if (questionMC != null)
                return questionMC;

            var questionSS = await _questionSingleSelectionRepository.GetById(id);

            if (questionSS != null)
                return questionSS;

            return null;
        }
    }
}
