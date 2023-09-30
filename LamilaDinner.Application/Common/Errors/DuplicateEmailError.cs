using System.Net;
using FluentResults;

namespace LamilaDinner.Application.Common.Errors;

public class DuplicateEmailError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}


// public record struct DuplicateEmailError : IError
// {
//     public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
//     public string ErrorMessage => "Email already exists.";
// }