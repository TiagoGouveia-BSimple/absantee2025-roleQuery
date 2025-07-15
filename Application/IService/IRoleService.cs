using Application.DTO;

namespace Application.IService;

public interface IRoleService
{
    Task<Result<CreatedRoleDTO>> Create(CreateRoleDTO addRoleDTO);
}
