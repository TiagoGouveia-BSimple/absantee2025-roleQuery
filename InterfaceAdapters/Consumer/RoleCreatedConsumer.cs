using Application.IService;
using Domain.Message;
using MassTransit;

namespace InterfaceAdapters.Consumer;

public class RoleCreatedConsumer : IConsumer<RoleCreatedMessage>
{
    private readonly IRoleService _roleService;

    public RoleCreatedConsumer(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task Consume(ConsumeContext<RoleCreatedMessage> context)
    {
        var msg = context.Message;
        await _roleService.CreateConsumed(msg.Id, msg.Description);
    }
}
