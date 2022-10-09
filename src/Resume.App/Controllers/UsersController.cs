using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using kr.bbon.AspNetCore;
using kr.bbon.AspNetCore.Models;
using kr.bbon.Core;
using kr.bbon.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resume.App.Infrastructure.Mvc;
using Resume.Domains.Users.Commands.CreateUser;
using Resume.Domains.Users.Models;
using Resume.Domains.Users.Queries.GetUserById;
using Resume.Domains.Users.Queries.GetUserByUsername;

namespace Resume.App.Controllers;

[ApiController]
[Area(DefaultValues.AreaName)]
[Route(DefaultValues.RouteTemplate)]
[ApiVersion(DefaultValues.ApiVersion)]
[Authorize]
[Produces(PRODUCE_MIMETYPE)]
public class UsersController : ApiContractBase
{
    public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator, logger)
    {
    }

    /// <summary>
    /// Get user by username
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    [HttpGet("me")]
    [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponseModel<ErrorModel>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponseModel<ErrorModel>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserInfo()
    {
        var userId = Request.HttpContext.User.Identity.Name;

        if (!Guid.TryParse(userId, out var id))
        {
            throw new ApiException(StatusCodes.Status401Unauthorized, "");
        }

        UserModel result = null;
        var tries = 0;
        do
        {
            try
            {
                result = await Mediator.Send(new GetUserByIdQuery(id));

                break;
            }
            catch
            {
                var emailClaim = Request.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault();
                var email = emailClaim?.Value;

                var nameClaim = Request.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();
                var name = nameClaim?.Value;
                var command = new CreateUserCommand()
                {
                    UserId = id,
                    Name = name,
                    Username = email,
                };

                var addedUser = await Mediator.Send(command);
            }

            tries += 1;
        }
        while (tries < 2);

        if (result == null)
        {
            throw new ApiException(System.Net.HttpStatusCode.NotFound, "Could not find a user");
        }


        return Ok(result);
    }
}