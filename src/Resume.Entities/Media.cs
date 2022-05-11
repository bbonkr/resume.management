using kr.bbon.Data.Abstractions.Entities;

namespace Resume.Entities;

public abstract class Media : EntityBase<Guid>
{
    public string Uri { get; set; }

    public string Name { get; set; }

    public string MimeType { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
}