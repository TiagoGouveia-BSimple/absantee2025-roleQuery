using Application.DTO;

namespace Application.IService;

public interface IRoleService
{
    Task<Result<CreatedRoleDTO>> Create(CreateRoleDTO addRoleDTO);
    Task CreateConsumed(Guid id, string description);
    Task<Result<IEnumerable<RoleDTO>>> GetAll();
    Task<Result<RoleDTO?>> GetById(Guid id);
}
