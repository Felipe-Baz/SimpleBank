using simplebank.mappers;

namespace simplebank.UnitTest.Infrastructure.Mappers
{
    public class UserProfileTest
    {
        public MapperConfiguration MapperConfiguration =
            new(cfg => cfg.AddProfile<UserProfile>());

        [Fact]
        public void UserCreateDtoToUser()
        {
            var userCreateDto = new UserCreateDTO
            {
                Fullname = "test fullname",
                Email = "test1@example.com",
                PhoneNumber = "11912581464",
                Cep = "032130120",
                Street = "Av Faria Lima",
                AddressNumber = "12",
                Complement = "casa",
                District = "Itaim bibi",
                State = "São Paulo",
                City = "São Paulo",
                Country = "Brasil"
            };

            var mapper = MapperConfiguration.CreateMapper();
            var user = mapper.Map<User>(userCreateDto);

            Assert.Equal(userCreateDto.Fullname, user.Fullname);
            Assert.Equal(userCreateDto.Email, user.Email);
            Assert.Equal(userCreateDto.PhoneNumber, user.PhoneNumber);
            Assert.Equal(userCreateDto.Cep, user.Cep);
            Assert.Equal(userCreateDto.Street, user.Street);
            Assert.Equal(userCreateDto.AddressNumber, user.AddressNumber);
            Assert.Equal(userCreateDto.Complement, user.Complement);
            Assert.Equal(userCreateDto.AddressNumber, user.AddressNumber);
            Assert.Equal(userCreateDto.District, user.District);
            Assert.Equal(userCreateDto.State, user.State);
            Assert.Equal(userCreateDto.City, user.City);
            Assert.Equal(userCreateDto.Country, user.Country);
        }

        [Fact]
        public void UserUpdateDtoToUser()
        {
            var userUpdateDto = new UserUpdateDTO
            {
                Id = 1,
                Fullname = "test fullname Updated",
                Email = "testUpdated@example.com",
                PhoneNumber = "11912581464",
                Cep = "032130120",
                Street = "Av Faria Lima",
                AddressNumber = "12",
                Complement = "casa",
                District = "Itaim bibi",
                State = "São Paulo",
                City = "São Paulo",
                Country = "Brasil"
            };

            var mapper = MapperConfiguration.CreateMapper();
            var user = mapper.Map<User>(userUpdateDto);

            Assert.Equal(userUpdateDto.Fullname, user.Fullname);
            Assert.Equal(userUpdateDto.Email, user.Email);
            Assert.Equal(userUpdateDto.PhoneNumber, user.PhoneNumber);
            Assert.Equal(userUpdateDto.Cep, user.Cep);
            Assert.Equal(userUpdateDto.Street, user.Street);
            Assert.Equal(userUpdateDto.AddressNumber, user.AddressNumber);
            Assert.Equal(userUpdateDto.Complement, user.Complement);
            Assert.Equal(userUpdateDto.AddressNumber, user.AddressNumber);
            Assert.Equal(userUpdateDto.District, user.District);
            Assert.Equal(userUpdateDto.State, user.State);
            Assert.Equal(userUpdateDto.City, user.City);
            Assert.Equal(userUpdateDto.Country, user.Country);
        }

        [Fact]
        public void UserToUserResponseDto()
        {
            var user = new User
            {
                Id = 1,
                Fullname = "test fullname",
                Email = "test1@example.com",
                PhoneNumber = "11912581464",
                Cep = "032130120",
                Street = "Av Faria Lima",
                AddressNumber = "12",
                Complement = "casa",
                District = "Itaim bibi",
                State = "São Paulo",
                City = "São Paulo",
                Country = "Brasil",
                Status = "CREATED",
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var mapper = MapperConfiguration.CreateMapper();
            var userResponseDTO = mapper.Map<UserResponseDTO>(user);

            Assert.Equal(userResponseDTO.Id, user.Id);
            Assert.Equal(userResponseDTO.Fullname, user.Fullname);
            Assert.Equal(userResponseDTO.Email, user.Email);
            Assert.Equal(userResponseDTO.PhoneNumber, user.PhoneNumber);
            Assert.Equal(userResponseDTO.Cep, user.Cep);
            Assert.Equal(userResponseDTO.Street, user.Street);
            Assert.Equal(userResponseDTO.AddressNumber, user.AddressNumber);
            Assert.Equal(userResponseDTO.Complement, user.Complement);
            Assert.Equal(userResponseDTO.AddressNumber, user.AddressNumber);
            Assert.Equal(userResponseDTO.District, user.District);
            Assert.Equal(userResponseDTO.State, user.State);
            Assert.Equal(userResponseDTO.City, user.City);
            Assert.Equal(userResponseDTO.Country, user.Country);
            Assert.Equal(userResponseDTO.CreatedAt, user.CreatedAt);
            Assert.Equal(userResponseDTO.UpdatedAt, user.UpdatedAt);
        }
    }
}