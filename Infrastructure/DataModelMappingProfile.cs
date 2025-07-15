using AutoMapper;
using Domain.IModel;
using Infrastructure.DataModel;
using Infrastructure.Resolver;

namespace Infrastructure;

public class DataModelMappingProfile : Profile
{
    public DataModelMappingProfile()
    {
        CreateMap<IRole, RoleDataModel>();
        CreateMap<RoleDataModel, IRole>()
            .ConvertUsing<RoleDataModelConverter>();
    }

}