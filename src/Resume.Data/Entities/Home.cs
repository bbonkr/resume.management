using kr.bbon.Data;
using System.Collections.Generic;

namespace Resume.Data.Entities
{
    public class Home : Entity<long>
    {
        //public long Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Intro { get; set; }

        public string Bio { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<HomeLink> HomeLinks { get; set; }
    }

    public class HomeLink : Entity
    {
        public long HomeId { get; set; }

        public virtual Home Home { get; set; }

        public long LinkId { get; set; }

        public virtual Link Link { get; set; }
    }
}
