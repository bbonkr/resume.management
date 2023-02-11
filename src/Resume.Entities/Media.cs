using System;

namespace Resume.Entities;

public abstract class Media
{
    public Guid Id { get; set; }

    public string Uri { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Content type of media
    /// </summary>
    public string ContentType { get; set; } = "application/octet-stream";

    public Guid UserId { get; set; }

    public virtual User? User { get; set; }
}