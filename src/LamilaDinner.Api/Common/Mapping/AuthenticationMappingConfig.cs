using LamilaDinner.Application.Services.Authentication.Commands.Register;
using LamilaDinner.Application.Services.Authentication.Common;
using LamilaDinner.Application.Services.Authentication.Queries.Login;
using LamilaDinner.Contracts.Authentication;
using Mapster;

namespace LamilaDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest, src => src.User);
    }
}