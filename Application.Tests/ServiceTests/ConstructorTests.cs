using Application.Service;
using Domain.IFactory;
using Domain.IRepository;
using Moq;

namespace Application.Tests.ServiceTests;

public class ConstructorTests
{
    [Fact]
    public void WhenGivenCorrectArguments_ThenObjectIsInstantiated()
    {
        // Arrange
        var roleRepository = new Mock<IRoleRepository>();
        var roleFactory = new Mock<IRoleFactory>();

        // Act
        new RoleService(roleRepository.Object, roleFactory.Object);
    
        // Then
    }
}
