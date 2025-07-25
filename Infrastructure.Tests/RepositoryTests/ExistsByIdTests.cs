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

public class ExistsById
{
    [Fact]
    public async Task WhenExistingIdIsPassed_ThenReturnTrue()
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
        var result = await roleRepository.ExistsById(id);

        // Assert
        Assert.True(result);
    }
}
