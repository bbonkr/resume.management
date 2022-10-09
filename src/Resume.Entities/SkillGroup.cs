using System;

namespace Resume.Entities;

public class SkillGroup
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public SkillGroupIcon Icon { get; set; } = SkillGroupIcon.Star;

    public virtual ICollection<Skill> Skills { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }
}