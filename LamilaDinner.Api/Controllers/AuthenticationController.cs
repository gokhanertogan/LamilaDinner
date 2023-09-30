using ErrorOr;
using FluentResults;
using LamilaDinner.Api.Filters;
using LamilaDinner.Application.Common.Errors;
using LamilaDinner.Application.Services.Authentication;
using LamilaDinner.Contracts.Authentication;
using LamilaDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace LamilaDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        // OneOf<AuthenticationResult, IError> registerResult = _authService.Register(
        //     request.FirstName,
        //     request.LastName,
        //     request.Email,
        //     request.Password);

        // return registerResult.Match(
        //     authResult => Ok(MapAuthResult(authResult)),
        //     error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
        // );

        ErrorOr<AuthenticationResult> registerResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
        // return registerResult.MatchFirst(
        //     authResult => Ok(MapAuthResult(authResult)),
        //     firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description));
        // if (registerResult.IsSuccess)
        // {
        //     return Ok(MapAuthResult(registerResult.Value));
        // }

        // var firstError = registerResult.Errors[0];

        // if (firstError is DuplicateEmailError)
        // {
        //     return Problem(statusCode: StatusCodes.Status409Conflict, detail: "Email already exists.");
        // }

        // return Problem();
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authService.Login(
            request.Email,
            request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
        // return authResult.MatchFirst(
        //     result => Ok(MapAuthResult(result)),
        //     firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description));
    }
}