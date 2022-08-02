using System;
using kr.bbon.Data.Repositories;
using Microsoft.Extensions.Logging;
using Resume.Data;
using Resume.Entities;

namespace Resume.DataStore.Repositories;

public class ContentRepository : RepositoryBase<AppDbContext, Content>
{
    public ContentRepository(AppDbContext context, ILogger<ContentRepository> logger) : base(context, logger)
    {
    }
}

public class ContentLinkRepository : RepositoryBase<AppDbContext, ContentLink>
{
    public ContentLinkRepository(AppDbContext context, ILogger<ContentLinkRepository> logger) : base(context, logger)
    {
    }
}


public class ContentMediaRepository : RepositoryBase<AppDbContext, ContentMedia>
{
    public ContentMediaRepository(AppDbContext context, ILogger<ContentMediaRepository> logger) : base(context, logger)
    {
    }
}

public class ContentTagRepository : RepositoryBase<AppDbContext, ContentTag>
{
    public ContentTagRepository(AppDbContext context, ILogger<ContentTagRepository> logger) : base(context, logger)
    {
    }
}

public class SkillRepository : RepositoryBase<AppDbContext, Skill>
{
    public SkillRepository(AppDbContext context, ILogger<SkillRepository> logger) : base(context, logger)
    {
    }
}

public class SkillGroupRepository : RepositoryBase<AppDbContext, SkillGroup>
{
    public SkillGroupRepository(AppDbContext context, ILogger<SkillGroupRepository> logger) : base(context, logger)
    {
    }
}

public class TagRepository : RepositoryBase<AppDbContext, Tag>
{
    public TagRepository(AppDbContext context, ILogger<TagRepository> logger) : base(context, logger)
    {
    }
}

public class UserRepository : RepositoryBase<AppDbContext, User>
{
    public UserRepository(AppDbContext context, ILogger<UserRepository> logger) : base(context, logger)
    {
    }
}

public class UserLinkRepository : RepositoryBase<AppDbContext, UserLink>
{
    public UserLinkRepository(AppDbContext context, ILogger<UserLinkRepository> logger) : base(context, logger)
    {
    }
}

public class UserMediaRepository : RepositoryBase<AppDbContext, UserMedia>
{
    public UserMediaRepository(AppDbContext context, ILogger<UserMediaRepository> logger) : base(context, logger)
    {
    }
}

public class UserSnsRepository : RepositoryBase<AppDbContext, UserSns>
{
    public UserSnsRepository(AppDbContext context, ILogger<UserSnsRepository> logger) : base(context, logger)
    {
    }
}