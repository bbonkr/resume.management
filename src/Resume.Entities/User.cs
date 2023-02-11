using System;

namespace Resume.Entities;

public class User
{
    /// <summary>
    /// User id from identity server
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Unique
    /// </summary>
    public string Username { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<UserSns> Sns { get; set; } = new HashSet<UserSns>();

    public virtual ICollection<UserLink> Links { get; set; } = new HashSet<UserLink>();

    public virtual ICollection<UserMedia> Files { get; set; } = new HashSet<UserMedia>();

    public virtual ICollection<Content> Contents { get; set; } = new HashSet<Content>();

    public virtual ICollection<Skill> Skills { get; set; } = new HashSet<Skill>();

    public virtual ICollection<SkillGroup> SkillGroups { get; set; } = new HashSet<SkillGroup>();

    public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

    public virtual ICollection<ContentGroup> ContentGroups { get; set; } = new HashSet<ContentGroup>();

    public virtual UserMetadata? Metadata { get; set; }
}
