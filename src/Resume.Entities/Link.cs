namespace Resume.Entities;

public abstract class Link
{
    public Guid Id { get; set; }

    public string Href { get; set; }

    public LinkIcon Icon { get; set; } = LinkIcon.None;

    public LinkTarget Target { get; set; } = LinkTarget.Self;

    public string Title { get; set; }

    public bool Enabled { get; set; } = true;

    public Guid UserId { get; set; }

    public User User { get; set; }
}