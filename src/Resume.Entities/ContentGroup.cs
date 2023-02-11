namespace Resume.Entities;

public class ContentGroup
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public User? User { get; set; }
}

