using AutoMapper;
using Domain.IFactory;
using Domain.IModel;
using Domain.Model;
using Infrastructure.DataModel;
using Infrastructure.Repository;
using Infrastructure.Resolver;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Infrastructure.Tests.RepositoryTests;

public class GetById
{
    [Fact]
    public void WhenExistingIdIsPassed_ThenReturnObject()
    {
        // Arrange
        var id = Guid.NewGuid();
        var role = new RoleDataModel(id, "description");

        var options = new DbContextOptionsBuilder<RoleContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new RoleContext(options);
        context.Roles.Add(role);
        context.SaveChanges();

        var roleFactory = new Mock<IRoleFactory>();
        roleFactory.Setup(r => r.Create(role)).Returns(
            new Role(role.Id, role.Description)
        );

        var converter = new RoleDataModelConverter(roleFactory.Object);

        var loggingFactory = NullLoggerFactory.Instance;

        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<IRole, RoleDataModel>();
            cfg.CreateMap<RoleDataModel, IRole>().ConvertUsing(converter);
        }, loggingFactory);
        var mapper = mockMapper.CreateMapper();

        var roleRepository = new RoleRepository(context, mapper);

        // Act
        var result = roleRepository.GetById(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(role.Id, result.Id);
        Assert.Equal(role.Description, result.Description);
    }
}
