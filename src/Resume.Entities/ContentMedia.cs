namespace Resume.Entities;

public class ContentMedia : Media
{
    public Guid ContentId { get; set; }

    public virtual Content Content { get; set; }
}