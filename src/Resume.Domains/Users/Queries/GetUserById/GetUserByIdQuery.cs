using System;
using MediatR;
using Resume.Domains.Users.Models;

namespace Resume.Domains.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserModel>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
