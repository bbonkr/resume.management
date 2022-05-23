using kr.bbon.Data.Abstractions.Entities;

namespace Resume.Entities;

public class Content : EntityBase<Guid>
{
    public string Title { get; set; }

    public string Subtitle { get; set; }

    public string Period { get; set; }

    public string State { get; set; }

    public string Description { get; set; }
    
    public ContentGroup Group { get; set; }

    public virtual ICollection<ContentMedia> Files { get; set; }

    public virtual ICollection<ContentLink> Links { get; set; }

    public bool Enabled { get; set; } = true;
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
    
    public virtual  ICollection<ContentTag> ContentTags { get; set; }
    
    public virtual  ICollection<Tag> Tags { get; set; }
}

