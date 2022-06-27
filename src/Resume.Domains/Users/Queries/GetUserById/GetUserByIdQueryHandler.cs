using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Resume.DataStore.Abstractions;
using Resume.Domains.Users.Models;
using Resume.Entities;
using kr.bbon.Data.Abstractions;
using kr.bbon.Data.Abstractions.Specifications;
using AutoMapper;

namespace Resume.Domains.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserModel>
{
    public GetUserByIdQueryHandler(IAppDataStore dataStore, IMapper mapper, ILogger<GetUserByIdQueryHandler> logger)
    {
        _dataStore = dataStore;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var specification = new SpecificationBuilder<User, UserModel>()
            .AddCriteria(x => x.Id == request.Id)
            .Build();

        var model = await _dataStore.UserRepository.GetOneAsync(specification);

        return model;
    }

    private readonly IAppDataStore _dataStore;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
}