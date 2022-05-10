using System.Collections.Generic;

namespace Resume.App.Infrastructure.Identity;

public class IdentityServer4Options
{
    public const string Name = "IdentityServer4";

    public string Issuer { get; set; }

    public string ApiName { get; set; }

    public IEnumerable<Scope> Scopes { get; set; }

    public string ClientSecret { get; set; }

    public SwaggerClient SwaggerClient { get; set; }
}

public class Scope
{
    public string Name { get; set; }

    public string DisplayName { get; set; }
}

public class SwaggerClient
{
    public string Id { get; set; }

    public string Name { get; set; }
}
