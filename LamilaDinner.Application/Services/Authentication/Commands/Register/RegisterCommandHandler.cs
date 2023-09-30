using ErrorOr;
using LamilaDinner.Application.Common.Interfaces.Authentication;
using LamilaDinner.Application.Common.Interfaces.Persistence;
using LamilaDinner.Application.Services.Authentication.Common;
using LamilaDinner.Domain.Common.Errors;
using LamilaDinner.Domain.Entities;
using MediatR;

namespace LamilaDinner.Application.Services.Authentication.Commands.Register;

public record RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(request.Email) is not null)
        {
            return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.User.DuplicateEmail);
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        _userRepository.Add(user);
        var token = _jwtTokenGenerator.GenerateToken(user);

        return Task.FromResult<ErrorOr<AuthenticationResult>>(new AuthenticationResult(user, token));
    }
}
