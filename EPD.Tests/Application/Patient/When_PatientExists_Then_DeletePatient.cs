using FluentAssertions;
using Moq;

namespace EPD.Tests.Application.Patient
{
    public class When_PatientExists_Then_DeletePatient
    {
        [Fact]
        public async Task Test()
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
            mock.Setup(repository => repository.GetPatientByIdAsync(1)).ReturnsAsync(patient);
            mock.Setup(repository => repository.DeletePatientAsync(patient)).Returns(Task.CompletedTask);

            var patientService = new EPD.Application.Services.PatientService(mock.Object);

            // Act
            await patientService.DeletePatientAsync(1);

            // Assert
            mock.Verify(repository => repository.GetPatientByIdAsync(1), Times.Once);
            mock.Verify(repository => repository.DeletePatientAsync(patient), Times.Once);
        }
    }
}
