using Domain.IModel;
using Domain.Model;
using Domain.Visitor;

namespace Domain.IFactory;

public interface IRoleFactory
{
    Task<IRole> Create(string description);
    Role Create(IRoleVisitor visitor);
}
