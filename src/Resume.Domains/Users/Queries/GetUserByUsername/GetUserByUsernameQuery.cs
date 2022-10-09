using System;
using MediatR;
using Resume.Domains.Users.Models;

namespace Resume.Domains.Users.Queries.GetUserByUsername;

public class GetUserByUsernameQuery : IRequest<UserModel>
{
    public GetUserByUsernameQuery(string username)
    {
        Username = username;
    }

    public string Username { get; private set; }
}
