using LamilaDinner.Domain.HostAggregate.ValueObjects;
using LamilaDinner.Domain.UserAggregate.ValueObjects;

namespace LamilaDinner.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Host
    {
        public static readonly HostId Id = HostId.Create(UserId.CreateUnique());
    }
}