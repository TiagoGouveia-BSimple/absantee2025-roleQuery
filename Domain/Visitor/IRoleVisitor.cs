namespace Domain.Visitor;

public interface IRoleVisitor
{
    Guid Id { get; }
    string Description { get; }
}
