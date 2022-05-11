using kr.bbon.Data.Abstractions.Entities;

namespace Resume.Entities;

public class User : EntityBase<Guid>
{
    /// <summary>
    /// User id from identity server
    /// </summary>
    public Guid UserId { get; set; }

    public string Name { get; set; }

    public string Username { get; set; }

    // public string Photo { get; set; }

    public string SiteTitle { get; set; }

    public string SiteTitleEn { get; set; }

    public string NameEn { get; set; }

    public string Url { get; set; }

    /// <summary>
    /// Home section title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Home section subtitle
    /// </summary>
    public string Subtitle { get; set; }

    public string Intro { get; set; }

    public string Bio { get; set; }

    public virtual ICollection<UserSns> Sns { get; set; }

    public virtual ICollection<UserLink> Links { get; set; }

    public virtual ICollection<UserMedia> Files { get; set; }
    
    public virtual ICollection<Content> Contents { get; set; }
    
    public virtual ICollection<Skill> Skills { get; set; }
    
    public virtual ICollection<SkillGroup> SkillGroups { get; set; }
}