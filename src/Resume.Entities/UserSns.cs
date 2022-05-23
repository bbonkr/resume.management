using kr.bbon.Data.Abstractions.Entities;

namespace Resume.Entities;

public class UserSns : EntityBase
{
    public SnsName ServiceName { get; set; }
    
    /// <summary>
    /// Account name
    /// </summary>
    public string Username { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
}