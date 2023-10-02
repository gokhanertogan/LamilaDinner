using ErrorOr;
using FluentResults;
using LamilaDinner.Application.Common.Errors;
using LamilaDinner.Application.Common.Interfaces.Authentication;
using LamilaDinner.Application.Common.Interfaces.Persistence;
using LamilaDinner.Application.Services.Authentication.Common;
using LamilaDinner.Domain.Common.Errors;
using LamilaDinner.Domain.Entities;

namespace LamilaDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
            // throw new Exception("User with given email does not exist.");
        }

        if (user.Password != password)
        {
            return new[] { Errors.Authentication.InvalidCredentials };
            // throw new Exception("Invalid password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            //throw new DuplicateEmailException();
            // return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}