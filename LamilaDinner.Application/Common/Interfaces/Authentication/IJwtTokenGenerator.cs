using LamilaDinner.Domain.Entities;

namespace LamilaDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}