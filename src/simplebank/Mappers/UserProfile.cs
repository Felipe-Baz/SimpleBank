using AutoMapper;
using simplebank.Model;

namespace simplebank.mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateUserProfile();
        }

        private void CreateUserProfile()
        {
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserResponseDTO>();
        }
        
    }
}