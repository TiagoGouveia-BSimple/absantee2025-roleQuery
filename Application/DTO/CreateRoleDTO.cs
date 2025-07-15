namespace Application.DTO;

public record CreateRoleDTO
{
    public string Description { get; set; }

    public CreateRoleDTO(string description)
    {
        Description = description;
    }
}
