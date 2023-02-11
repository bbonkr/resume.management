namespace Resume.Entities;

public class UserSns
{
    public SnsName ServiceName { get; set; }

    /// <summary>
    /// Account name
    /// </summary>
    public string Username { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public User? User { get; set; }
}
