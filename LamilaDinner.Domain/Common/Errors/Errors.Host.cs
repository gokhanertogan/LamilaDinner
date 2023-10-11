using ErrorOr;

namespace LamilaDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Host
    {
        public static Error CouldNotBeFound => Error.NotFound(
            code: "Host.CouldNotBeFound",
            description: "host could not be found.");
    }
}