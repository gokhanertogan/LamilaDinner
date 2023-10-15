using LamilaDinner.Application.Services.Authentication.Commands.Register;
using LamilaDinner.Application.Services.Authentication.Common;
using LamilaDinner.Application.Services.Authentication.Queries.Login;
using LamilaDinner.Contracts.Authentication;
using LamilaDinner.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LamilaDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var registerResult = await _mediator.Send(command);

        return registerResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));

        #region  Comments
        // OneOf<AuthenticationResult, IError> registerResult = _authService.Register(
        //     request.FirstName,
        //     request.LastName,
        //     request.Email,
        //     request.Password);

        // return registerResult.Match(
        //     authResult => Ok(MapAuthResult(authResult)),
        //     error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
        // );

        // ErrorOr<AuthenticationResult> registerResult = _authenticationCommandService.Register(
        //     request.FirstName,
        //     request.LastName,
        //     request.Email,
        //     request.Password);


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
        #endregion
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
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}