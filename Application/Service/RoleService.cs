using Application.DTO;
using Application.IService;
using Domain.IFactory;
using Domain.IRepository;

namespace Application.Service;

public class RoleService : IRoleService
{
    private readonly IRoleRepository RoleRepository;
    private readonly IRoleFactory RoleFactory;

    public RoleService(IRoleRepository roleRepository, IRoleFactory roleFactory)
    {
        RoleRepository = roleRepository;
        RoleFactory = roleFactory;
    }
    public async Task<Result<CreatedRoleDTO>> Create(CreateRoleDTO createRoleDTO)
    {
        try
        {
            var role = await RoleFactory.Create(createRoleDTO.Description);
            role = await RoleRepository.AddAsync(role);

            var res = new CreatedRoleDTO(role.Id, role.Description);
            return Result<CreatedRoleDTO>.Success(res);
        }
        catch (ArgumentException ex)
        {
            return Result<CreatedRoleDTO>.Failure(Error.InternalServerError(ex.Message));
        }
    }
}
