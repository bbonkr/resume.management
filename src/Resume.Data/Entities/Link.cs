using kr.bbon.Data;

namespace Resume.Data.Entities
{
    public class Link : Entity<long>
    {
        //public long Id { get; set; }   

        public string Title { get; set; }

        public string Href { get; set; }

        public LinkIcon Icon { get; set; }

        public LinkTarget Target { get; set; }
    }

    public enum LinkIcon
    {
        [StringValue("github")]
        GitHub,
        [StringValue("blog")]
        Blog,
        [StringValue("home")]
        Home,
        [StringValue("mail")]
        Mail,
    }

    public enum LinkTarget
    {
        [StringValue("_blank")]
        Blank,
        [StringValue("_self")]
        Self,
    }
}
