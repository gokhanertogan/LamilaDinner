using LamilaDinner.Domain.Entities;

namespace LamilaDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}