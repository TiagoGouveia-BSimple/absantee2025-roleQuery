using System.ComponentModel.DataAnnotations.Schema;
using Domain.Visitor;

namespace Infrastructure.DataModel;

[Table("Roles")]
public class RoleDataModel : IRoleVisitor
{
    public Guid Id { get; set; }
    public string Description { get; set; }

    public RoleDataModel(Guid id, string description)
    {
        Id = id;
        Description = description;
    }
}
