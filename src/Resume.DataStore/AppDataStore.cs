using kr.bbon.Data.Abstractions;
using kr.bbon.Data.Services;
using Microsoft.Extensions.Logging;
using Resume.Data;
using Resume.DataStore.Abstractions;
using Resume.Entities;

namespace Resume.DataStore;

public class AppDataStore : DataServiceBase<AppDbContext>, IAppDataStore
{
    public AppDataStore(
        AppDbContext context,
        ILogger<AppDataStore> logger,
        IRepository<Content> contentRepository,
        IRepository<ContentLink> contentLinkRepository,
        IRepository<ContentMedia> contentMediaRepository,
        IRepository<ContentTag> contentTagRepository,
        IRepository<Skill> skillRepository,
        IRepository<SkillGroup> skillGroupRepository,
        IRepository<Tag> tagRepository,
        IRepository<User> userRepository,
        IRepository<UserLink> userLinkRepository,
        IRepository<UserMedia> userMediaRepository,
        IRepository<UserSns> userSnsRepository)
        : base(context, logger)
    {
        _contentRepository = contentRepository;

        _contentLinkRepository = contentLinkRepository;

        _contentMediaRepository = contentMediaRepository;

        _contentTagRepository = contentTagRepository;

        _skillRepository = skillRepository;

        _skillGroupRepository = skillGroupRepository;

        _tagRepository = tagRepository;

        _userRepository = userRepository;

        _userLinkRepository = userLinkRepository;

        _userMediaRepository = userMediaRepository;

        _userSnsRepository = userSnsRepository;

    }

    public IRepository<Content> ContentRepository { get => _contentRepository; }

    public IRepository<ContentLink> ContentLinkRepository { get => _contentLinkRepository; }

    public IRepository<ContentMedia> ContentMediaRepository { get => _contentMediaRepository; }

    public IRepository<ContentTag> ContentTagRepository { get => _contentTagRepository; }

    public IRepository<Skill> SkillRepository { get => _skillRepository; }

    public IRepository<SkillGroup> SkillGroupRepository { get => _skillGroupRepository; }

    public IRepository<Tag> TagRepository { get => _tagRepository; }

    public IRepository<User> UserRepository { get => _userRepository; }

    public IRepository<UserLink> UserLinkRepository { get => _userLinkRepository; }

    public IRepository<UserMedia> UserMediaRepository { get => _userMediaRepository; }

    public IRepository<UserSns> UserSnsRepository { get => _userSnsRepository; }

    private readonly IRepository<Content> _contentRepository;

    private readonly IRepository<ContentLink> _contentLinkRepository;

    private readonly IRepository<ContentMedia> _contentMediaRepository;

    private readonly IRepository<ContentTag> _contentTagRepository;

    private readonly IRepository<Skill> _skillRepository;

    private readonly IRepository<SkillGroup> _skillGroupRepository;

    private readonly IRepository<Tag> _tagRepository;

    private readonly IRepository<User> _userRepository;

    private readonly IRepository<UserLink> _userLinkRepository;

    private readonly IRepository<UserMedia> _userMediaRepository;

    private readonly IRepository<UserSns> _userSnsRepository;
}
