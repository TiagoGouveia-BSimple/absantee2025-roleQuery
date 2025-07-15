using Domain.IFactory;
using Domain.IModel;
using Domain.IRepository;
using Domain.Model;
using Domain.Visitor;

namespace Domain.Factory;

public class RoleFactory : IRoleFactory
{
    public async Task<IRole> Create(string description)
    {
        return new Role(Guid.NewGuid(), description);
    }

    public IRole Create(IRoleVisitor visitor)
    {
        return new Role(visitor.Id, visitor.Description);
    }
}
