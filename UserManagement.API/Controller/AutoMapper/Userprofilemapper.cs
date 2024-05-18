
using AutoMapper;
using Domain;
using UserManagement.API.DTO;


namespace UserManagement.API.Controller.AutoMapper
{
    public class Userprofilemapper : Profile
    {
        public Userprofilemapper()
        {

            CreateMap<UserProfileDTO, User>();
            //.ForMember(u => u.UserName, p => p.MapFrom(udto => udto.UserName))
            //.ForMember(u => u.Email, p => p.MapFrom(udto => udto.Email))
            //.ForMember(u => u.Password, p => p.MapFrom(udto => udto.Password));

            CreateMap<UserProfileDTO, UserProfile>()
            .ForMember(up => up.FirstName, p => p.MapFrom(udto => udto.FName))
            .ForMember(up => up.LastName, p => p.MapFrom(udto => udto.LName));
            //.ForMember(up => up.Address, p => p.MapFrom(udto => udto.Address));

        }


    }
}