using kr.bbon.Data.Abstractions;
using Resume.Entities;

namespace Resume.DataStore.Abstractions;

public interface IAppDataStore : IDataService
{
    public IRepository<Content> ContentRepository { get; }

    public IRepository<ContentLink> ContentLinkRepository { get; }

    public IRepository<ContentMedia> ContentMediaRepository { get; }

    public IRepository<ContentTag> ContentTagRepository { get; }

    public IRepository<Skill> SkillRepository { get; }

    public IRepository<SkillGroup> SkillGroupRepository { get; }

    public IRepository<Tag> TagRepository { get; }

    public IRepository<User> UserRepository { get; }

    public IRepository<UserLink> UserLinkRepository { get; }

    public IRepository<UserMedia> UserMediaRepository { get; }

    public IRepository<UserSns> UserSnsRepository { get; }
}
