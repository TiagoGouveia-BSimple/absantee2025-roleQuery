using AutoMapper;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Infrastructure.Tests.RepositoryTests;

public class ConstructorTests
{
    [Fact]
    public void WhenConstructorIsCalledWithValidParameters_ThenObjectIsInstantiated()
    {
        // Arrange

        // Act
        new RoleRepository(It.IsAny<RoleContext>(), It.IsAny<IMapper>());

        // Assert
    }
}
