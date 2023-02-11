namespace Resume.Entities;

public class ContentLink : Link
{
    public Guid ContentId { get; set; }

    public virtual Content? Content { get; set; }
}