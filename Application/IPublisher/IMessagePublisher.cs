namespace Application.IPublisher;

public interface IMessagePublisher
{
    Task PublishRoleCreatedMessageAsync(Guid id, string description);
}
