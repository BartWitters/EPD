using FluentAssertions;

namespace EPD.Tests.Domain
{
    public class When_EmailIsInvalid_Then_ThrowException
    {
        [Theory]
        [InlineData("")]
        [InlineData("john.Doegmail.com")]
        public void Test(string invalid)
        {
            // Arrange & Act
            Action action = () => new EPD.Domain.ValueObjects.Email(invalid);

            // Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}
