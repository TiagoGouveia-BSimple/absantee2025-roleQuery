using Domain.Factory;

namespace Domain.Tests.FactoryTests;

public class CreateTests
{
    [Fact]
    public async Task WhenGivenValidArguments_ThenRoleIsCreated()
    {
        // Arrange
        var factory = new RoleFactory();
        var description = "description";

        // Act
        var result = await factory.Create(description);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(description, result.Description);
    }
}
