using ErrorOr;
using LamilaDinner.Application.Services.Authentication.Common;

namespace LamilaDinner.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}