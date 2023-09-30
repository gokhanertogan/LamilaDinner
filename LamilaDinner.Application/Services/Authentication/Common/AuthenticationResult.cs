using LamilaDinner.Domain.Entities;

namespace LamilaDinner.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);

