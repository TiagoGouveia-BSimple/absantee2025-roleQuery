using Domain.Factory;
using Domain.Visitor;
using Moq;

namespace Domain.Tests.FactoryTests;

public class CreateWithVisitorTests
{
    [Fact]
    public void WhenGivenValidArguments_ThenRoleIsCreated()
    {
        // Arrange
        var factory = new RoleFactory();
        var id = Guid.NewGuid();
        var description = "description";

        var visitor = new Mock<IRoleVisitor>();
        visitor.Setup(v => v.Id).Returns(id);
        visitor.Setup(v => v.Description).Returns(description);

        // Act
        var result = factory.Create(visitor.Object);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(description, result.Description);
    }
}

