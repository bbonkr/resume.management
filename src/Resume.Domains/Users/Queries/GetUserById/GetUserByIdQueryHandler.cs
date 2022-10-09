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

public class GetUserByIdQueryHandler : RequestHandlerBase<GetUserByIdQuery, UserModel>
{
    public GetUserByIdQueryHandler(AppDbContext dbContext, IMapper mapper, ILogger<GetUserByIdQueryHandler> logger)
        : base(dbContext, mapper, logger)
    {

    }

    public override async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken = default)
    {
        var model = await _DbContext.Users
            .Where(x => x.Id == request.Id)
            .Select(x => _Mapper.Map<UserModel>(x))
            .FirstOrDefaultAsync(cancellationToken);

        if (model == null)
        {
            throw new ApiException(System.Net.HttpStatusCode.NotFound, "Could not find a user");
        }

        return model;
    }
}