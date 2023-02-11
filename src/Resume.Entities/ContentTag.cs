
namespace Resume.Entities;

public class ContentTag
{
    public Guid ContentId { get; set; }

    public Guid TagId { get; set; }

    public virtual Content? Content { get; set; }

    public virtual Tag? Tag { get; set; }
}