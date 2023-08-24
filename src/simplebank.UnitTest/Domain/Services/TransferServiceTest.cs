namespace simplebank.UnitTest.Domain.Services
{
    public class TransferServiceTest
    {
        [Fact]
        public async Task CreateTestAsync()
        {
            int id = 1;
            var transfer = new Transfer
            {
                Id = 1,
                FromUserId = 1,
                FromUser = new User {
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
                },
                ToUserId = 2,
                Amount = 20.0,
                ToUser = new User {
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
                },
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            //Act
            var mockRepository = new Mock<ITransferRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(transfer);

            var mockService = new TransferService(mockRepository.Object);
            var result = await mockService.CreateAsync(transfer);

            Assert.Equal(transfer, result);
        }

        [Fact]
        public async Task ListTestAsync()
        {
            var transferOne = new Transfer
            {
                Id = 1,
                FromUserId = 1,
                FromUser = new User {
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
                },
                ToUserId = 2,
                Amount = 20.0,
                ToUser = new User {
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
                },
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var transferTwo = new Transfer
            {
                Id = 2,
                FromUserId = 2,
                FromUser = new User {
                    Id = 2,
                    Fullname = "test2 fullname",
                    Email = "test2@example.com",
                    PhoneNumber = "11912282264",
                    Cep = "032132120",
                    Street = "Av Faria Lima",
                    AddressNumber = "122",
                    Complement = "casa",
                    District = "Itaim bibi",
                    State = "São Paulo",
                    City = "São Paulo",
                    Country = "Brasil",
                    Status = "CREATED",
                    CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                    UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
                },
                ToUserId = 3,
                Amount = 200.0,
                ToUser = new User {
                    Id = 3,
                    Fullname = "test3 fullname",
                    Email = "test3@example.com",
                    PhoneNumber = "11933581464",
                    Cep = "032330120",
                    Street = "Av Faria Lima",
                    AddressNumber = "123",
                    Complement = "casa",
                    District = "Itaim bibi",
                    State = "São Paulo",
                    City = "São Paulo",
                    Country = "Brasil",
                    Status = "CREATED",
                    CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                    UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
                },
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var transfers = new List<Transfer>
            {
                transferOne,
                transferTwo
            };

            //Act
            var mockRepository = new Mock<ITransferRepository>();
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(transfers);

            var mockService = new TransferService(mockRepository.Object);
            var result = await mockService.ListAsync();

            Assert.Equal(transfers, result);
        }

        [Fact]
        public async Task DetailsTestAsync()
        {
            int id = 1;
            var transfer = new Transfer
            {
                Id = 1,
                FromUserId = 1,
                FromUser = new User {
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
                },
                ToUserId = 2,
                Amount = 20.0,
                ToUser = new User {
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
                },
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            //Act
            var mockRepository = new Mock<ITransferRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(transfer);

            var mockService = new TransferService(mockRepository.Object);
            var result = await mockService.DetailsAsync(id);

            Assert.Equal(transfer, result);
        }

        [Fact]
        public async Task CreateTransferWithoutAmountTestAsync()
        {
            int id = 1;
            var transfer = new Transfer
            {
                Id = 1,
                FromUserId = 1,
                FromUser = new User {
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
                },
                ToUserId = 2,
                Amount = 0,
                ToUser = new User {
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
                },
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            //Act
            var mockRepository = new Mock<ITransferRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(transfer);

            var mockService = new TransferService(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<ValidationException>(() => mockService.CreateAsync(transfer));

            //Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task CreateTransferWithNegativeAmountTestAsync()
        {
            int id = 1;
            var transfer = new Transfer
            {
                Id = 1,
                FromUserId = 1,
                FromUser = new User {
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
                },
                ToUserId = 2,
                Amount = -1,
                ToUser = new User {
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
                },
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            //Act
            var mockRepository = new Mock<ITransferRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(transfer);

            var mockService = new TransferService(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<ValidationException>(() => mockService.CreateAsync(transfer));

            //Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task CreateTransferForTheSameUserTestAsync()
        {
            int id = 1;
            var transfer = new Transfer
            {
                Id = 1,
                FromUserId = 1,
                FromUser = new User {
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
                },
                ToUserId = 1,
                Amount = 10,
                ToUser = new User {
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
                },
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            //Act
            var mockRepository = new Mock<ITransferRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(transfer);

            var mockService = new TransferService(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<ValidationException>(() => mockService.CreateAsync(transfer));

            //Assert
            Assert.NotNull(exception);
        }
    }
}