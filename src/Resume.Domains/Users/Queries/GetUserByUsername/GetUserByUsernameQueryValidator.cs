using FluentValidation;

namespace Resume.Domains.Users.Queries.GetUserByUsername;

public class GetUserByUsernameQueryValidator : AbstractValidator<GetUserByUsernameQuery>
{
    public GetUserByUsernameQueryValidator()
    {
        RuleFor(x => x.Username).NotEmpty().NotNull()
            .WithErrorCode("username_required")
            .WithMessage(payload => $"Username is required");
    }
}