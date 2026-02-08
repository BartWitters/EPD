using Moq;

namespace EPD.Tests.Application.Patient
{
    public class When_PatientDoesNotExists_Then_DoNotDeletePatient
    {
        [Fact]
        public async Task Test()
        {
            // Arrange
            var patient = (EPD.Domain.Entities.Patient?)null;

            var mock = new Mock<EPD.Application.Interfaces.IPatientRepository>();
            mock.Setup(repository => repository.GetPatientByIdAsync(1)).ReturnsAsync(patient);

            var patientService = new EPD.Application.Services.PatientService(mock.Object);

            // Act
            await patientService.DeletePatientAsync(1);

            // Assert
            mock.Verify(repository => repository.GetPatientByIdAsync(It.IsAny<int>()), Times.Once);
            mock.Verify(repository => repository.DeletePatientAsync(It.IsAny<EPD.Domain.Entities.Patient>()), Times.Never);
        }
    }
}
