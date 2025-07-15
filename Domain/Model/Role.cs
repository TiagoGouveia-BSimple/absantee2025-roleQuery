using Domain.IModel;

namespace Domain.Model;

public class Role : IRole
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }

    public Role(Guid id, string description)
    {
        Id = id;
        Description = description;
    }

    public  void UpdateDescription(string newDescription)
    {
        Description = newDescription;
    }
}
