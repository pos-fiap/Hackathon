using Hackathon.Application.DTOs;
using Hackathon.Application.Services;
using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;
using Moq;
using Xunit;

namespace Hackathon.Tests.Services
{
    [Collection("PatientService")]
    public class PatientServiceTest
    {
        private readonly Mock<IPatientRepository> _patientRepository;
        private readonly Mock<IPersonRepository> _personRepository;

        public PatientServiceTest()
        {
            _patientRepository = new Mock<IPatientRepository>();
            _personRepository = new Mock<IPersonRepository>();
        }


        [Fact]
        public async Task Add_WhenCalled_ReturnsPatient()
        {
            // Arrange
            _personRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(new Person() { CPF = "1212323", Name = "Luana" });
            var patientService = new PatientService();
            var patientRequestDto = new PatientDto() { HealthInsuranceNumber = "1111" };
            var postPatientRequestDto = new PostPatientDto() { HealthInsuranceNumber = "1111" };

            // Act
            var result = await patientService.Create(postPatientRequestDto);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAll_WhenCalled_ReturnsPatient()
        {


            // Arrange
            var patientService = new PatientService();
            var person = new Person() { CPF = "1212323", Name = "Luana" };

            var patient = new List<Patient>
            {
                new(){ HealthInsuranceNumber = "1111", PersonId = 23, Person = person },
                new(){ HealthInsuranceNumber = "1122", PersonId = 24, Person = person }
            };

            _patientRepository.Setup(x => x.GetAsync()).ReturnsAsync(patient);

            // Act
            var result = await patientService.Get();

            // Assert
            Assert.NotNull(result);

        }


        [Fact]
        public async Task GetById_WhenCalled_ReturnsPatient()
        {
            // Arrange
            var patientService = new PatientService();
            var person = new Person() { CPF = "1212323", Name = "Luana" };
            var patient = new List<Patient>
            {
                new(){ HealthInsuranceNumber = "1111", PersonId = 23, Person = person },
                new(){ HealthInsuranceNumber = "1122", PersonId = 24, Person = person }
            };

            _patientRepository.Setup(x => x.GetAsync()).ReturnsAsync(patient);

            // Act
            var result = await patientService.Get(1);

            // Assert
            Assert.NotNull(result);

        }

        [Fact]
        public async Task Remove_WhenCalled_ReturnsVoid()
        {
            // Arrange
            var patientService = new PatientService();
            var person = new Person() { CPF = "1212323", Name = "Luana" };
            var patient = new List<Patient>
            {
                new(){ HealthInsuranceNumber = "1111", PersonId = 23, Person = person },
                new(){ HealthInsuranceNumber = "1122", PersonId = 24, Person = person }
            };

            // Act
            await patientService.Delete(1);

            // Assert
            _patientRepository.Verify(x => x.Delete(It.IsAny<Patient>()), Times.Once);
        }

        [Fact]
        public async Task Update_WhenCalled_ReturnsVoid()
        {
            // Arrange           
            var patientDto = new PatientDto() { HealthInsuranceNumber = "1111" };
            var patientService = new PatientService();

            // Act
            await patientService.Update(patientDto);

            // Assert
            _patientRepository.Verify(x => x.Update(It.IsAny<Patient>()), Times.Once);
        }
    }
}
