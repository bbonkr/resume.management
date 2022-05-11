using kr.bbon.Data.Abstractions.Entities;

namespace Resume.Entities;

public class Skill : EntityBase<Guid>
{
    public string Title { get; set; }

    public string Description { get; set; }

    public double Score { get; set; }

    public double ScoreMax { get; set; }

    public Guid SkillGroupId { get; set; }

    public virtual SkillGroup Group { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }
}