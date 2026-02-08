using FluentAssertions;

namespace EPD.Tests.Application.Patient
{
    
    public class When_PatientIsNotValid_Then_DoNotCreatePatient
    {
        [Theory]
        [InlineData("")]
        public void Test(string invalidStreet)
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";
            DateOnly dateOfBirth = new DateOnly(1990, 9, 19);
            string nationalRegisterNumber = "90091912345";
            int streetNumber = 123;
            int aptNumber = 1;
            string city = "Google city";
            string emailAddress = "John.Doe@gmail.com";

            // Act
            var patient = () => EPD.Domain.Entities.Patient.Create(firstName, lastName, dateOfBirth, nationalRegisterNumber, invalidStreet, streetNumber, aptNumber, city, emailAddress);

            // Assert
            patient.Should().Throw<ArgumentException>().WithMessage("Street is required. (Parameter 'street')");
        }
    }
}
