namespace Domain.Entities.Common;

public class BaseEntity
{
    protected BaseEntity(Guid id) => Id = id;

    protected BaseEntity()
    {
    }

    public Guid Id { get; protected set; }
}