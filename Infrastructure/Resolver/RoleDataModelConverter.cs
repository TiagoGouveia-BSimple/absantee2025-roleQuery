using AutoMapper;
using Domain.IFactory;
using Domain.IModel;
using Infrastructure.DataModel;

namespace Infrastructure.Resolver;

public class RoleDataModelConverter : ITypeConverter<RoleDataModel, IRole>
{
    private readonly IRoleFactory _roleFactory;

    public RoleDataModelConverter(IRoleFactory roleFactory)
    {
        _roleFactory = roleFactory;
    }

    public IRole Convert(RoleDataModel source, IRole destination, ResolutionContext context)
    {
        var res = _roleFactory.Create(source);
        return res;
    }

    public bool UpdateDataModel(RoleDataModel RoleDataModel, IRole RoleDomain)

    {
        RoleDataModel.Id = RoleDomain.Id;

        // pode ser necessário mais atualizações, e com isso o retorno não ser sempre true
        // contudo, porque RoleDataModel está a ser gerido pelo DbContext, para atualizarmos a DB, é este que tem de ser alterado, e não criar um novo

        RoleDataModel.Description = RoleDomain.Description;
        return true;
    }
}