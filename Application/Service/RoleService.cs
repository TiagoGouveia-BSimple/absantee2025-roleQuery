using Application.DTO;
using Application.IService;
using Domain.IFactory;
using Domain.IRepository;
using Infrastructure.DataModel;
using Infrastructure.Repository;

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

    public async Task CreateConsumed(Guid id, string description)
    {
        if (await RoleRepository.ExistsById(id)) return;

        var roleDM = new RoleDataModel(id, description);

        var role = RoleFactory.Create(roleDM);

        await RoleRepository.AddAsync(role);
    }

    public async Task<Result<IEnumerable<RoleDTO>>> GetAll()
    {
        try
        {
            var roles = await RoleRepository.GetAllAsync();
            var res = roles.Select(r => new RoleDTO(r.Id, r.Description));

            return Result<IEnumerable<RoleDTO>>.Success(res);
        }
        catch (ArgumentException ex)
        {
            return Result<IEnumerable<RoleDTO>>.Failure(Error.InternalServerError(ex.Message));
        }
    }

    public async Task<Result<RoleDTO?>> GetById(Guid id)
    {
        try
        {
            var role = await RoleRepository.GetByIdAsync(id);

            if (role == null)
                return Result<RoleDTO?>.Success(null);

            var res = new RoleDTO(role.Id, role.Description);

            return Result<RoleDTO?>.Success(res);
        }
        catch (ArgumentException ex)
        {
            return Result<RoleDTO?>.Failure(Error.InternalServerError(ex.Message));
        }
    }
}
