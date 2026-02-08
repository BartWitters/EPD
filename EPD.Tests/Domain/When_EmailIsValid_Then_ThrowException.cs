using FluentAssertions;

namespace EPD.Tests.Domain
{
    public class When_EmailIsValid_Then_NotThrow
    {
        [Theory]
        [InlineData("John.Doe@gmail.com")]
        public void Test(string validEmailAddress)
        {
            // Arrange & Act
            Action action = () => new EPD.Domain.ValueObjects.Email(validEmailAddress);

            // Assert
            action.Should().NotThrow();
        }
    }
}
