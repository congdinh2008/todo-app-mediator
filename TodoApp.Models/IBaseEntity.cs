namespace TodoApp.Models;

public interface IBaseEntity
{
    Guid Id { get; set; }

    DateTime InsertedAt { get; set; }

    DateTime? UpdatedAt { get; set; }

    DateTime? DeletedAt { get; set; }

    bool IsActive { get; set; }
}
