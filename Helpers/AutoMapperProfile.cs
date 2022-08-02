namespace WebApi.Helpers;

using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.Contracts;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // UserCreateRequest -> User
        CreateMap<UserCreateRequest, User>();

        // UserUpdateRequest -> User
        CreateMap<UserUpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    // ignore null role
                    if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                    return true;
                }
            ));

        // ContractCreateRequest -> Contract
        CreateMap<ContractCreateRequest, Contract>();

        // ContractUpdateRequest -> Contract
        CreateMap<ContractUpdateRequest, Contract>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
        
    }
}