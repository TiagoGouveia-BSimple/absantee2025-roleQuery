using Domain.Factory;

namespace Domain.Tests.FactoryTests;

public class ConstructorTests
{
    [Fact]
    public void WhenGivenValidArguments_ThenObjectIsInstantiated()
    {
        // Arrange

        // Act
        new RoleFactory();
    
        // Assert
    }
}
