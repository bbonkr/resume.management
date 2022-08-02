using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

using Resume.Domains.Users.Models;
using Resume.Entities;
using AutoMapper;
using Resume.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using kr.bbon.Core;

namespace Resume.Domains.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserModel>
{
    public GetUserByIdQueryHandler(AppDbContext dbContext, IMapper mapper, ILogger<GetUserByIdQueryHandler> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken = default)
    {
        var model = await _dbContext.Users
            .Where(x => x.Id == request.Id)
            .Select(x => _mapper.Map<UserModel>(x))
            .FirstOrDefaultAsync(cancellationToken);

        if (model == null)
        {
            throw new ApiException(System.Net.HttpStatusCode.NotFound);
        }

        return model;
    }

    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
}