using System.Net;

namespace LamilaDinner.Application.Common.Errors;

public interface IErrorOneOf
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}