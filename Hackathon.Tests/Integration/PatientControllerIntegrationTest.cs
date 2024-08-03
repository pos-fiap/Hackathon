//using Hackathon.Api.Controllers;
//using Hackathon.Application.DTOs;
//using Hackathon.Application.Services;
//using Hackathon.Domain.Entities;
//using Hackathon.Infra.Data.Context;
//using Hackathon.Infra.Data.Repositories;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Xunit;

//namespace Hackathon.Tests.Integration
//{
//    [Collection("PatientIntegration")]
//    public class PatientControllerIntegrationTest : BaseIntegrationTest
//    {
//        private DbContextOptions<ApplicationContext> _dbContextOptions;
//        private ApplicationContext _applicationContext;
//        private PatientRepository _patientRepository;
//        private PersonRepository _personRepository;
//        private PatientService _patientService;        
//        private PatientController _patientController;
//        private Patient _patient;
//        private Person _person;
        
//        public PatientControllerIntegrationTest() : base()
//        {
//            Configure();
//        }

//        private void Configure()
//        {
//            _dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(ConnectionString).Options;
//            _applicationContext = new ApplicationContext(_dbContextOptions);
//            _patientRepository = new PatientRepository(_applicationContext);
//            //_patientService = new PatientService(_patientRepository, _personRepository);
            
//        }

//        private void SeedDatabase(ApplicationContext dbContext)
//        {
//            CreatePatient(dbContext);

//            dbContext.Patients.Add(_patient);
//            dbContext.SaveChanges();
//        }

//        private void CreatePatient(ApplicationContext dbContext)
//        {
//            var existingPatient = dbContext.Patients.FirstOrDefault(b => b.PersonId == 23);
           

//            if (existingPatient is not null)
//            {
//                _patient = existingPatient;
//                return;
//            }

            

//            _person = new Person() { CPF = "1212323", Name="Luana"};

//            _patient = new Patient() { HealthInsuranceNumber = "1111", PersonId = 23, Person = _person};
//        }

//        private void Delete(ApplicationContext dbContext)
//        {
//            var existingPatient = dbContext.Patients.FirstOrDefault(b => b.PersonId == 23);


//            if (existingPatient != null)
//            {
//                dbContext.Patients.Remove(existingPatient);
//                dbContext.SaveChanges();
//            }
               
//        }

//        [Fact]
//        public async Task Add_Returns_CreatedResultWithNewPatient()
//        {
//            //Arrange
//            CreatePatient(_applicationContext);

//            var _patientDto = new PostPatientDto() { HealthInsuranceNumber = _patient.HealthInsuranceNumber };
//            // Act
//            var result = await _patientController.Post(_patientDto);

//            // Assert
//            var createdResult = Assert.IsType<CreatedResult>(result);

//            var patient = Assert.IsType<Patient>(createdResult.Value);
//            Assert.Equal(_patientDto.HealthInsuranceNumber, patient.HealthInsuranceNumber);

            Delete(_applicationContext);
        }

        [Fact]
        public async Task GetPatients_Returns_AllPatient()
        {
            SeedDatabase(_applicationContext);
            // Act
            var result = await _patientController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Patient>>(okResult.Value);

            Delete(_applicationContext);
        }

        [Fact]
        public async Task GetById_Returns_Patient()
        {
            // Arrange
            SeedDatabase(_applicationContext);

            // Act
            var result = await _patientController.Get(_patient.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Patient>>(okResult.Value);

            Delete(_applicationContext);
        }

        [Fact]
        public async Task Update_Returns_OkResult()
        {
            // Arrange
            SeedDatabase(_applicationContext);
            var _patientDto = new PatientDto() { HealthInsuranceNumber = _patient.HealthInsuranceNumber };

            // Act
            var result = await _patientController.Put(_patientDto);

//            // Assert
//            Assert.IsType<OkResult>(result);

            Delete(_applicationContext);
        }

//        [Fact]
//        public async Task Remove_Returns_OkResult()
//        {
//            // Arrange
//            SeedDatabase(_applicationContext);

            // Act
            var result = await _patientController.Delete(_patient.Id);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
