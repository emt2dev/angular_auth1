using AngularAuthAPI.DTOModels;
using AngularAuthAPI.Models;
using AutoMapper;

namespace AngularAuthAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
        }
    }
}
