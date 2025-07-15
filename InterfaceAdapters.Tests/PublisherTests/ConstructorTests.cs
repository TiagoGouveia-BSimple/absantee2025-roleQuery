using InterfaceAdapters.Publisher;
using MassTransit;
using Moq;

namespace InterfaceAdapters.Tests.PublisherTests;

public class ConstructorTests
{
    [Fact]
    public async Task WhenGivenCorrectArguments_ThenObjectIsInstantiated()
    {
        // Arrange
        var publishEndpoint = new Mock<IPublishEndpoint>();

        // Act
        new MassTransitPublisher(publishEndpoint.Object);

        // Assert
    }
}
