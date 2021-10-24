using kr.bbon.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data.Entities
{
    public class Skill : Entity<long>
    {
        public string Title { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }

        public ICollection<SkillGroup> Groups { get; set; }
    }

    public class SkillGroup : Entity<long>
    {
        public string Title { get; set; }

        public SkillGroupIcon Icon { get; set; }

        public long SkillId { get; set; }

        public virtual Skill Skill { get; set; }

        public ICollection<SkillItem> Items { get; set; }
    }

    public class SkillItem : Entity<long>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Score { get; set; }

        public int ScoreMax { get; set; }

        public bool IsDisabled { get; set; } = false;

        public string href { get; set; }

        public long SkillGroupId { get; set; }

        public virtual SkillGroup Group { get; set; }
    }

    public enum SkillGroupIcon
    {
        [StringValue("star")]
        Star,
        [StringValue("like")]
        Like,
    }
}
