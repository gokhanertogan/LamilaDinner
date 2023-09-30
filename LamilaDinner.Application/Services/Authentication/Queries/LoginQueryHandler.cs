using ErrorOr;
using LamilaDinner.Application.Common.Interfaces.Authentication;
using LamilaDinner.Application.Common.Interfaces.Persistence;
using LamilaDinner.Application.Services.Authentication.Common;
using LamilaDinner.Domain.Entities;
using LamilaDinner.Domain.Common.Errors;
using MediatR;

namespace LamilaDinner.Application.Services.Authentication.Queries;

public record LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(request.Email) is not User user)
        {
            return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.Authentication.InvalidCredentials);
        }

        if (user.Password != request.Password)
        {
            return Task.FromResult<ErrorOr<AuthenticationResult>>(new[] { Errors.Authentication.InvalidCredentials });
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return Task.FromResult<ErrorOr<AuthenticationResult>>(new AuthenticationResult(
            user,
            token
        ));
    }
}
