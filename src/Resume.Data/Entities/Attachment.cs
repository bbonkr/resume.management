using kr.bbon.Data;

namespace Resume.Data.Entities
{
    public class Attachment : Entity<long>
    {
        //public long Id { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public string Mimetype { get; set; } = "application/octet-stream";

        public long Size { get; set; } = 0;

        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}
