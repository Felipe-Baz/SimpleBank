using simplebank.Facades;

namespace simplebank.UnitTest.Application.Facades
{
    public class TransferFacadeTest
    {
        [Fact]
        public async Task CreateTransferTest()
        {
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

            var transferCreateDto = new TransferCreateDTO
            {
                FromUserId = 1,
                ToUserId = 2,
                Amount = 20.0
            };

            var transferResponseDto = new TransferResponseDTO
            {
                Id = 1,
                FromUserId = 1,
                FromUser = new UserResponseDTO {
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
                },
                ToUserId = 2,
                Amount = 20.0,
                ToUser = new UserResponseDTO {
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
                },
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var mockService = new Mock<ITransferService>();
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Transfer>(transferCreateDto)).Returns(transfer);
            mockMapper.Setup(x => x.Map<TransferResponseDTO>(transfer)).Returns(transferResponseDto);

            mockService.Setup(x => x.CreateAsync(transfer)).ReturnsAsync(transfer);

            var mockFacade = new TransferFacade(mockService.Object, mockMapper.Object);
            var result = await mockFacade.CreateAsync(transferCreateDto);

            //Assert
            Assert.Equal(transferResponseDto, result);
        }

        [Fact]
        public async Task DetailsTransferTest() {
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

            var transferResponseDto = new TransferResponseDTO
            {
                Id = 1,
                FromUserId = 1,
                FromUser = new UserResponseDTO {
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
                },
                ToUserId = 2,
                Amount = 20.0,
                ToUser = new UserResponseDTO {
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
                },
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var mockService = new Mock<ITransferService>();
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<TransferResponseDTO>(transfer)).Returns(transferResponseDto);

            mockService.Setup(x => x.DetailsAsync(id)).ReturnsAsync(transfer);

            var mockFacade = new TransferFacade(mockService.Object, mockMapper.Object);
            var result = await mockFacade.DetailsAsync(id: id);

            //Assert
            Assert.Equal(transferResponseDto, result);
        }
    
        [Fact]
        public async Task ListTransferTest() {
            
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

            var transferResponseOne = new TransferResponseDTO
            {
                Id = 1,
                FromUserId = 1,
                FromUser = new UserResponseDTO {
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
                },
                ToUserId = 2,
                Amount = 20.0,
                ToUser = new UserResponseDTO {
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
                },
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var transferResponseTwo = new TransferResponseDTO
            {
                Id = 2,
                FromUserId = 2,
                FromUser = new UserResponseDTO {
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
                    CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                    UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
                },
                ToUserId = 3,
                Amount = 200.0,
                ToUser = new UserResponseDTO {
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
                    CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                    UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
                },
                CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
            };

            var transfersResponse = new List<TransferResponseDTO>
            {
                transferResponseOne,
                transferResponseTwo
            };

            var mockService = new Mock<ITransferService>();
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<List<TransferResponseDTO>>(transfers)).Returns(transfersResponse);
            mockService.Setup(x => x.ListAsync()).ReturnsAsync(transfers);

            //Act
            var mockFacade = new TransferFacade(mockService.Object, mockMapper.Object);
            var result = await mockFacade.ListAsync();
            
            //Assert
            Assert.Equal(transfersResponse.Count, result.Count);
        }
    }
}