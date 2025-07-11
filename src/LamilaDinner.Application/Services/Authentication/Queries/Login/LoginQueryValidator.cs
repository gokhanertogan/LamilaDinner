using FluentValidation;

namespace LamilaDinner.Application.Services.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x=>x.Email).NotEmpty();
        RuleFor(x=> x.Password).NotEmpty();
    }
}