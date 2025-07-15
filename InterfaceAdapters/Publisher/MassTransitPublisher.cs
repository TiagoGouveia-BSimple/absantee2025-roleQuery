using Application.IPublisher;
using Domain.Message;
using MassTransit;

namespace InterfaceAdapters.Publisher;

public class MassTransitPublisher : IMessagePublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MassTransitPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishRoleCreatedMessageAsync(Guid id, string description)
    {
        await _publishEndpoint.Publish(new RoleCreatedMessage(id, description));   
    }
}
