using Domain.IModel;
using Domain.Model;
using Domain.Visitor;

namespace Domain.IRepository;

public interface IRoleRepository : IGenericRepositoryEF<IRole, Role, IRoleVisitor>
{
    Task<bool> ExistsById(Guid id);
}
