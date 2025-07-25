using Domain.Model;

namespace Domain.Tests.ModelTests;

public class ConstructorTests
{
    [Fact]
    public void WhenGivenCorrectArguments_ThenObjectIsInstantiated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var description = "description";

        // Act
        new Role(id, description);

        // Assert
    }
}
