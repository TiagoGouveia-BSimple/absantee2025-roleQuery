using Domain.Model;

namespace Domain.Tests.ModelTests;

public class UpdateDescriptionTests
{
    [Fact]
    public void WhenGivenCorrectArguments_ThenDescriptionIsChanged()
    {
        // Arrange
        var id = Guid.NewGuid();
        var description = "description";
        var role = new Role(id, description);

        // Act
        role.UpdateDescription("newDescription");

        // Assert
        Assert.Equal("newDescription", role.Description);
    }
}
