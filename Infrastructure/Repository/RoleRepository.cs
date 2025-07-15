using System.Threading.Tasks;
using AutoMapper;
using Domain.IModel;
using Domain.IRepository;
using Domain.Model;
using Infrastructure.DataModel;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class RoleRepository : GenericRepositoryEF<IRole, Role, RoleDataModel>, IRoleRepository
{
    private readonly IMapper _mapper;
    public RoleRepository(RoleContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public async Task<bool> ExistsById(Guid id)
    {
        return await _context.Set<RoleDataModel>().AnyAsync(r => r.Id == id);
    }

    public override IRole? GetById(Guid id)
    {
        var roleDM = _context.Set<RoleDataModel>().FirstOrDefault(r => r.Id == id);

        if (roleDM == null)
            return null;

        var role = _mapper.Map<RoleDataModel, Role>(roleDM);
        return role;
    }

    public override async Task<IRole?> GetByIdAsync(Guid id)
    {
        var roleDM = await _context.Set<RoleDataModel>().FirstOrDefaultAsync(r => r.Id == id);

        if (roleDM == null)
            return null;

        var role = _mapper.Map<RoleDataModel, Role>(roleDM);
        return role;
    }
}
