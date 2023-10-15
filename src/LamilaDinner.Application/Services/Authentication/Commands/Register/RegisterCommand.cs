using ErrorOr;
using LamilaDinner.Application.Services.Authentication.Common;
using MediatR;

namespace LamilaDinner.Application.Services.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;