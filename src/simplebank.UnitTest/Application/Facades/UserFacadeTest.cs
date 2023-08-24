using simplebank.Facades;

namespace simplebank.UnitTest.Application.Facades
{
    public class UserFacadeTest
    {
        [Fact]
        public async Task CreateUserTest()
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

            var userRequestDto = new UserCreateDTO
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

            var userResponseDto = new UserResponseDTO
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
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<User>(userRequestDto)).Returns(user);
            mockMapper.Setup(x => x.Map<UserResponseDTO>(user)).Returns(userResponseDto);

            mockService.Setup(x => x.CreateAsync(user)).ReturnsAsync(user);

            var mockFacade = new UserFacade(mockService.Object, mockMapper.Object);
            var result = await mockFacade.CreateAsync(userRequestDto);

            //Assert
            Assert.Equal(userResponseDto, result);
        }
    
        [Fact]
        public async Task DetailsTransferTest() {
            int id = 1;

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

            var userResponseDto = new UserResponseDTO
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
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<UserResponseDTO>(user)).Returns(userResponseDto);

            mockService.Setup(x => x.DetailsAsync(id)).ReturnsAsync(user);

            var mockFacade = new UserFacade(mockService.Object, mockMapper.Object);
            var result = await mockFacade.DetailsAsync(id: id);

            //Assert
            Assert.Equal(userResponseDto, result);
        }

        [Fact]
        public async Task ListUserTest() {
            
            var userOne = new User
            {
                Id = 1,
                Fullname = "test1 fullname",
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

            var userTwo = new User
            {
                Id = 2,
                Fullname = "test2 fullname",
                Email = "test2@example.com",
                PhoneNumber = "11922581464",
                Cep = "032230120",
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

            var users = new List<User>
            {
                userOne,
                userTwo
            };

            var userResponseOne = new UserResponseDTO
            {
                Id = 1,
                Fullname = "test1 fullname",
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
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var userResponseTwo = new UserResponseDTO
            {
                Id = 2,
                Fullname = "test2 fullname",
                Email = "test2@example.com",
                PhoneNumber = "11922581464",
                Cep = "032230120",
                Street = "Av Faria Lima",
                AddressNumber = "12",
                Complement = "casa",
                District = "Itaim bibi",
                State = "São Paulo",
                City = "São Paulo",
                Country = "Brasil",
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var usersResponse = new List<UserResponseDTO>
            {
                userResponseOne,
                userResponseTwo
            };

            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<List<UserResponseDTO>>(users)).Returns(usersResponse);
            mockService.Setup(x => x.ListAsync()).ReturnsAsync(users);

            //Act
            var mockFacade = new UserFacade(mockService.Object, mockMapper.Object);
            var result = await mockFacade.ListAsync();
            
            //Assert
            Assert.Equal(usersResponse.Count, result.Count);
        }

        [Fact]
        public async Task UpdateTest()
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

            var userRequestDto = new UserUpdateDTO
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

            var userResponseDto = new UserResponseDTO
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
                Country = "Brasil",
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<User>(userRequestDto)).Returns(user);
            mockMapper.Setup(x => x.Map<UserResponseDTO>(user)).Returns(userResponseDto);

            mockService.Setup(x => x.UpdateAsync(user)).ReturnsAsync(user);

            var mockFacade = new UserFacade(mockService.Object, mockMapper.Object);
            var result = await mockFacade.UpdateAsync(userRequestDto);

            //Assert
            Assert.Equal(userResponseDto, result);
        }

        [Fact]
        public async Task DeleteTest()
        {
            //Arrange
            const int id = 1;

            var mockService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();
            var mockFacade = new UserFacade(mockService.Object, mockMapper.Object);

            //Act
            var exception = await Record.ExceptionAsync(() => mockFacade.DeleteAsync(id));

            //Assert
            Assert.Null(exception);
        }
    }
}