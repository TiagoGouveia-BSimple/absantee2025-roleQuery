using Infrastructure.DataModel;
using Moq;
using Xunit;

namespace Infrastructure.Tests.DataModelTests;

public class ConstructorTests
{
    [Fact]
    public void WhenConstructorIsCalledWithValidParameters_ThenObjectIsInstantiated()
    {
        // Arrange

        // Act
        new RoleDataModel(It.IsAny<Guid>(), It.IsAny<string>());

        // Assert
    }
}
