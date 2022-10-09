using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resume.Data;
using Resume.Domains.Users.Models;
using Resume.Entities;

namespace Resume.Domains.Users.Commands.CreateUser;

public class CreateUserCommandHandler : RequestHandlerBase<CreateUserCommand, UserModel>
{
    public CreateUserCommandHandler(AppDbContext dbContext, IMapper mapper, ILogger<CreateUserCommandHandler> logger)
        : base(dbContext, mapper, logger)
    {
    }

    public override async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newEntity = _Mapper.Map<User>(request);
        newEntity.Id = request.UserId;

        var added = _DbContext.Users.Add(newEntity);

        await _DbContext.SaveChangesAsync(cancellationToken);

        var model = _Mapper.Map<UserModel>(added.Entity);

        return model;
    }
}
