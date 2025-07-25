using Application.DTO;
using Application.Service;
using Domain.IFactory;
using Domain.IModel;
using Domain.IRepository;
using Domain.Model;
using Domain.Visitor;
using Moq;

namespace Application.Tests.ServiceTests;

public class CreateTests
{
    [Fact]
    public async Task WhenGivenCorrectArguments_ThenSuccessIsReturned()
    {
        // Arrange
        var id = Guid.NewGuid();
        var description = "description";
        var role = new Mock<IRole>();
        role.Setup(e => e.Id).Returns(id);
        role.Setup(e => e.Description).Returns(description);

        var roleRepository = new Mock<IRoleRepository>();
        roleRepository.Setup(r => r.AddAsync(It.IsAny<IRole>())).ReturnsAsync(role.Object);
        
        var roleFactory = new Mock<IRoleFactory>();
        roleFactory.Setup(f => f.Create(It.IsAny<IRoleVisitor>())).Returns(role.Object);

        var createRoleDTO = new CreateRoleDTO(description);

        var roleService = new RoleService(roleRepository.Object, roleFactory.Object);

        // Act
        var result = await roleService.Create(createRoleDTO);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.Equal(description, result.Value.Description);
    }
}
