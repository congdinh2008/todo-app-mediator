namespace TodoApp.Models;

public class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; }

    public DateTime InsertedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool IsActive { get; set; }
}