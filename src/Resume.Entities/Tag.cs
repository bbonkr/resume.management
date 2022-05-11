using kr.bbon.Data.Abstractions.Entities;

namespace Resume.Entities;

public class Tag : EntityBase<Guid>
{
    public string Title { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
}