using System;
using System.Collections.Generic;

namespace Resume.Entities;

public class Content
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Subtitle { get; set; } = string.Empty;

    public string Period { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsHidden { get; set; } = true;

    public Guid UserId { get; set; }

    public Guid ContentGroupId { get; set; }

    public virtual ContentGroup? Group { get; set; }

    public virtual ICollection<ContentMedia> Files { get; set; } = new HashSet<ContentMedia>();

    public virtual ICollection<ContentLink> Links { get; set; } = new HashSet<ContentLink>();

    public virtual User? User { get; set; }

    public virtual ICollection<ContentTag> ContentTags { get; set; } = new HashSet<ContentTag>();

    public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
}

