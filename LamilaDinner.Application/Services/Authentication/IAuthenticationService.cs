using ErrorOr;
using FluentResults;
using LamilaDinner.Application.Common.Errors;
using LamilaDinner.Application.Services.Authentication.Common;

namespace LamilaDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
    // OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password);
    // Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}