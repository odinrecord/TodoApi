namespace TodoApi.Models;

public class Todo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public PriorityLevel Priority { get; set; } = PriorityLevel.Medium;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public string? Category { get; set; }
}

public enum PriorityLevel
{
    Low = 1,
    Medium = 2,
    High = 3,
    Urgent = 4
}