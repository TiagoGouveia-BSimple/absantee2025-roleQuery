namespace Application.DTO;

public record CreatedRoleDTO
{
    public Guid Id { get; set; }
    public string Description { get; set; }

    public CreatedRoleDTO(Guid id, string description)
    {
        Id = id;
        Description = description;
    }
}
