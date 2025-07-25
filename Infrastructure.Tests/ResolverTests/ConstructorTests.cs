using Domain.IFactory;
using Infrastructure.Resolver;
using Moq;
using Xunit;

namespace Infrastructure.Tests.ResolverTests;

public class ConstructorTests
{
    [Fact]
    public void WhenConstructorIsCalledWithValidParameters_ThenObjectIsInstantiated()
    {
        // Arrange

        // Act
        new RoleDataModelConverter(It.IsAny<IRoleFactory>());
    
        // Assert
    }
}

