using System;

namespace Resume.Entities;

public class Tag
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public Guid UserId { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<ContentTag> ContentTags { get; set; }
    public virtual ICollection<Content> Contents { get; set; }
}