namespace Domain.IModel;

public interface IRole
{
    Guid Id { get; }
    string Description { get; }

    void UpdateDescription(string newDescription);
}
