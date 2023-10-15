using LamilaDinner.Application.Common.Interfaces.Services;

namespace LamilaDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}