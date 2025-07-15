namespace Application.DTO;

public record RoleDTO
{
    public Guid Id { get; set; }
    public string Description { get; set; }

    public RoleDTO()
    {

    }
}
