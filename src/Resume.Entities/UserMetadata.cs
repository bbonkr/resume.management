namespace Resume.Entities;

public class UserMetadata
{
    public Guid UserId { get; set; }

    public string SiteTitle { get; set; } = string.Empty;

    public string SiteTitleEn { get; set; } = string.Empty;

    public string NameEn { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Home section title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Home section subtitle
    /// </summary>
    public string Subtitle { get; set; } = string.Empty;

    public string Intro { get; set; } = string.Empty;

    public string Bio { get; set; } = string.Empty;

    public virtual User? User{ get; set; }
}