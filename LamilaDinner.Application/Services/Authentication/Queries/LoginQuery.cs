using ErrorOr;
using LamilaDinner.Application.Services.Authentication.Common;
using MediatR;

namespace LamilaDinner.Application.Services.Authentication.Queries;

public record LoginQuery(string Email,string Password) : IRequest<ErrorOr<AuthenticationResult>>;