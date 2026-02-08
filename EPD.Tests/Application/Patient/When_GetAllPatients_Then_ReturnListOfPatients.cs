using FluentAssertions;
using Moq;

namespace EPD.Tests.Application.Patient
{
    public class When_GetAllPatients_Then_ReturnListOfPatients
    {
        [Fact]
        public async Task TestAsync()
        {
            // Arrange
            var patient = new EPD.Domain.Entities.Patient
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateOnly(1990, 9, 19),
                NationalRegisterNumber = "90091912345",
                Street = "Google street",
                StreetNumber = 123,
                AptNumber = 1,
                City = "Google city",
                EmailAddress = "John.Doe@gmail.com"
            };

            var mock = new Mock<EPD.Application.Interfaces.IPatientRepository>();
            mock.Setup(repository => repository.GetAllPatientsAsync()).ReturnsAsync([patient]);

            var patientService = new EPD.Application.Services.PatientService(mock.Object);

            // Act
            var result = await patientService.GetAllPatientsAsync();

            // Assert
            Assert.NotNull(result);
            result.Should().HaveCount(1);
            result.First().FirstName.Should().Be("John");
            result.First().LastName.Should().Be("Doe");
        }
    }
}
