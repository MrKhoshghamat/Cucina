using AutoMapper;
using Cucina.Application.Features.User.Commands.Create.Model.Request;
using Cucina.Application.Features.User.Commands.Create.Model.Response;
using Cucina.Domain;

namespace Cucina.Application;

public class UserMapper : Profile
{
    #region Constructor and Mapping

    public UserMapper()
    {
        CreateMap<User, CreateUserCommandRequest>().ReverseMap();
        CreateMap<User, CreateUserCommandResponse>().ReverseMap();
        CreateMap<CreateUserCommandRequest, CreateUserCommandResponse>().ReverseMap();
    }

    #endregion
}