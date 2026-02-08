using FluentAssertions;

namespace EPD.Tests.Application.Patient
{
    public class When_PatientIsValid_Then_CreatePatient
    {
        [Fact]
        public void Test()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";
            DateOnly dateOfBirth = new DateOnly(1990, 9, 19);
            string nationalRegisterNumber = "90091912345";
            string street = "Google street";
            int streetNumber = 123;
            int aptNumber = 1;
            string city = "Google city";
            string emailAddress = "John.Doe@gmail.com";

            // Act
            var patient = EPD.Domain.Entities.Patient.Create(firstName, lastName, dateOfBirth, nationalRegisterNumber, street, streetNumber, aptNumber, city, emailAddress);

            // Assert
            patient.Should().NotBeNull();
            patient.FirstName.Should().Be(firstName);
            patient.LastName.Should().Be(lastName);
            patient.DateOfBirth.Should().Be(dateOfBirth);
            patient.NationalRegisterNumber.Should().Be(nationalRegisterNumber);
            patient.Street.Should().Be(street);
            patient.StreetNumber.Should().Be(streetNumber);
            patient.AptNumber.Should().Be(aptNumber);
            patient.City.Should().Be(city);
            patient.EmailAddress.Should().Be(emailAddress);
        }
    }
}
