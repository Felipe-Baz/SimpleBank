namespace simplebank.UnitTest.Domain.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async Task DeleteTestAsync()
        {
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var result = await mockService.DeleteAsync(id);

            Assert.Equal(user, result);
        }

        [Fact]
        public async Task DetailsTestAsync()
        {
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var result = await mockService.DetailsAsync(id);

            Assert.Equal(user, result);
        }

        [Fact]
        public void ListTest()
        {
            Assert.True(true);
        }
        
        [Fact]
        public async Task CreateTestAsync()
        {
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var result = await mockService.CreateAsync(user);

            Assert.Equal(user, result);
        }

        [Theory]
        [InlineData("1894@")]
        [InlineData("aaa@com.   ")]
        [InlineData("aaa@@.com   ")]
        [InlineData("aaa   @gmail.com")]
        [InlineData("aaa   @gmail")]
        [InlineData("aaa@gmail.com   ")]
        [InlineData("@gmail.com")]
        public async Task CreateInvalidEmailFormatTestAsync(string email)
        {
            int id = 1;
            var user = new User
            {
                Id = 1,
                Fullname = "test fullname",
                Email = email,
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<ValidationException>(() => mockService.CreateAsync(user));

            //Assert
            Assert.NotNull(exception);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateEmailRequiredTestAsync(string email)
        {
            int id = 1;
            var user = new User
            {
                Id = 1,
                Fullname = "test fullname",
                Email = email,
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<ValidationException>(() => mockService.CreateAsync(user));

            //Assert
            Assert.NotNull(exception);
        }

        [Theory]
        [InlineData("aaaaa")]
        [InlineData("1")]
        [InlineData("11")]
        [InlineData("119")]
        [InlineData("1191")]
        [InlineData("11912")]
        [InlineData("119125")]
        [InlineData("1191258")]
        [InlineData("11912581")]
        [InlineData("119125814")]
        [InlineData("1191258146")]
        [InlineData("119125814643")]
        public async Task CreateInvalidPhoneNumberFormatTestAsync(string phoneNumber)
        {
            int id = 1;
            var user = new User
            {
                Id = 1,
                Fullname = "test fullname",
                PhoneNumber = phoneNumber,
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<ValidationException>(() => mockService.CreateAsync(user));

            //Assert
            Assert.NotNull(exception);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreatePhoneNumberRequiredTestAsync(string phoneNumber)
        {
            int id = 1;
            var user = new User
            {
                Id = 1,
                Fullname = "test fullname",
                PhoneNumber = phoneNumber,
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<ValidationException>(() => mockService.CreateAsync(user));

            //Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task UpdateTestAsync()
        {
            int id = 1;
            var user = new User
            {
                Id = 1,
                Fullname = "test fullname Edited",
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var result = await mockService.UpdateAsync(user);

            Assert.Equal(user, result);
        }

        [Theory]
        [InlineData("1894@")]
        [InlineData("aaa@com.   ")]
        [InlineData("aaa@@.com   ")]
        [InlineData("aaa   @gmail.com")]
        [InlineData("aaa   @gmail")]
        [InlineData("aaa@gmail.com   ")]
        [InlineData("@gmail.com")]
        public async Task UpdateInvalidEmailFormatTestAsync(string email)
        {
            int id = 1;
            var user = new User
            {
                Id = 1,
                Fullname = "test fullname",
                Email = email,
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<ValidationException>(() => mockService.UpdateAsync(user));

            //Assert
            Assert.NotNull(exception);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdateEmailRequiredTestAsync(string email)
        {
            int id = 1;
            var user = new User
            {
                Id = 1,
                Fullname = "test fullname",
                Email = email,
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<ValidationException>(() => mockService.UpdateAsync(user));

            //Assert
            Assert.NotNull(exception);
        }

        [Theory]
        [InlineData("aaaaa")]
        [InlineData("1")]
        [InlineData("11")]
        [InlineData("119")]
        [InlineData("1191")]
        [InlineData("11912")]
        [InlineData("119125")]
        [InlineData("1191258")]
        [InlineData("11912581")]
        [InlineData("119125814")]
        [InlineData("1191258146")]
        [InlineData("119125814643")]
        public async Task UpdateInvalidPhoneNumberFormatTestAsync(string phoneNumber)
        {
            int id = 1;
            var user = new User
            {
                Id = 1,
                Fullname = "test fullname",
                Email = "example@example.com",
                PhoneNumber = phoneNumber,
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<ValidationException>(() => mockService.UpdateAsync(user));

            //Assert
            Assert.NotNull(exception);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdatePhoneNumberRequiredTestAsync(string phoneNumber)
        {
            int id = 1;
            var user = new User
            {
                Id = 1,
                Fullname = "test fullname",
                Email = "example@example.com",
                PhoneNumber = phoneNumber,
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

            //Act
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(user);

            var mockService = new UserService(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<ValidationException>(() => mockService.UpdateAsync(user));

            //Assert
            Assert.NotNull(exception);
        }
    }
}