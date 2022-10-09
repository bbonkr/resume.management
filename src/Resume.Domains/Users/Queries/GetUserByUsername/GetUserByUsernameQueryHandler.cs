using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using kr.bbon.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Resume.Data;
using Resume.Domains.Users.Models;

namespace Resume.Domains.Users.Queries.GetUserByUsername;

public class GetUserByUsernameQueryHandler : RequestHandlerBase<GetUserByUsernameQuery, UserModel>
{
    public GetUserByUsernameQueryHandler(AppDbContext dbContext, IMapper mapper, ILogger<GetUserByUsernameQueryHandler> logger)
        : base(dbContext, mapper, logger)
    {

    }

    public override async Task<UserModel> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        var user = await _DbContext.Users
            .Where(x => x.Username == request.Username)
            .Select(x => _Mapper.Map<UserModel>(x))
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            throw new ApiException(System.Net.HttpStatusCode.NotFound, "Could not find a user");
        }

        return user;
    }


}
