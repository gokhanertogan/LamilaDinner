using ErrorOr;
using FluentResults;
using LamilaDinner.Application.Common.Errors;
using LamilaDinner.Application.Services.Authentication.Common;

namespace LamilaDinner.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}