using LamilaDinner.Domain.Entities;

namespace LamilaDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);

