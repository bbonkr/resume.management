using kr.bbon.Data.Abstractions.Entities;

namespace Resume.Entities;

public abstract class Media : EntityBase<Guid>
{
    public string Uri { get; set; }

    public string Name { get; set; }

    /// <summary>
    /// Content type of media
    /// </summary>
    public string ContentType { get; set; } = "application/octet-stream";
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
}