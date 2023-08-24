using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using simplebank.Data;
using simplebank.Repositories;

namespace simplebank.UnitTest.Infrastructure.Repositories
{
    public class UserRepositoryTest
    {
        [Fact]
        public async Task GetListTest()
        {
            var connection = CreateSqLiteConnection();
            connection.Open();

            try
            {
                var options = SetDbContextOptionsBuilder(connection);

                await using var context = new DBContext(options);
                Assert.True(await context.Database.EnsureCreatedAsync());

                //Arrange
                

                var userOne = new User
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

                var userTwo = new User
                {
                    Id = 2,
                    Fullname = "test fullname 2",
                    Email = "test2@example.com",
                    PhoneNumber = "11922581464",
                    Cep = "032130120",
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
                };

                //Act
                var repository = new UserRepository(context);
                repository.Add(userOne);
                repository.Add(userTwo);
                await repository.SaveChangesAsync();

                //Assert
                var result = await repository.GetAllAsync();
                Assert.Equal(2, result.Count);
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task GetByIdTest()
        {
            var connection = CreateSqLiteConnection();
            connection.Open();

            try
            {
                var options = SetDbContextOptionsBuilder(connection);

                await using var context = new DBContext(options);
                Assert.True(await context.Database.EnsureCreatedAsync());

                //Arrange
                
                int id = 1;
                var userOne = new User
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
                var repository = new UserRepository(context);
                repository.Add(userOne);
                await repository.SaveChangesAsync();

                //Assert
                var result = await repository.GetByIdAsync(id);
                Assert.Equal("test1@example.com", result.Email);
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task CreateOkTest()
        {
            var connection = CreateSqLiteConnection();
            connection.Open();

            try
            {
                var options = SetDbContextOptionsBuilder(connection);

                await using var context = new DBContext(options);
                Assert.True(await context.Database.EnsureCreatedAsync());

                //Arrange
                

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
                var repository = new UserRepository(context);
                repository.Add(user);
                var result = await repository.SaveChangesAsync();

                //Assert
                Assert.Equal(1, result);
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task DeleteTest()
        {
            var connection = CreateSqLiteConnection();
            connection.Open();

            try
            {
                var options = SetDbContextOptionsBuilder(connection);

                await using var context = new DBContext(options);
                Assert.True(await context.Database.EnsureCreatedAsync());

                int id = 1;
                var newUser = new User
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
                var repository = new UserRepository(context);
                repository.Add(newUser);
                await repository.SaveChangesAsync();

                var storedUser = await repository.GetByIdAsync(id);
                repository.Remove(storedUser);
                await repository.SaveChangesAsync();

                //Assert
                var nonExistentUser = await repository.GetByIdAsync(id);
                Assert.Null(nonExistentUser);
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task DuplicatedEmailTest()
        {
            var connection = CreateSqLiteConnection();
            connection.Open();

            try
            {
                var options = SetDbContextOptionsBuilder(connection);

                await using var context = new DBContext(options);
                Assert.True(await context.Database.EnsureCreatedAsync());

                var userOne = new User
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

                var userTwo = new User
                {
                    Id = 2,
                    Fullname = "test fullname 2",
                    Email = "test1@example.com",
                    PhoneNumber = "11912281464",
                    Cep = "032132120",
                    Street = "Av Faria Lima 2",
                    AddressNumber = "123",
                    Complement = "casa 2",
                    District = "Itaim bibi 2",
                    State = "São Paulo 2",
                    City = "São Paulo 2",
                    Country = "Brasil 2",
                    Status = "CREATED",
                    CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                    UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
                };

                //Act
                var repository = new UserRepository(context);
                repository.Add(userOne);
                await repository.SaveChangesAsync();

                //Assert
                repository.Add(userTwo);
                var exception =
                    await Assert.ThrowsAsync<DbUpdateException>(() => repository.SaveChangesAsync());
                Assert.NotNull(exception);
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task CreateInvalidEmailTest()
        {
            var connection = CreateSqLiteConnection();
            connection.Open();

            try
            {
                var options = SetDbContextOptionsBuilder(connection);

                await using var context = new DBContext(options);
                Assert.True(await context.Database.EnsureCreatedAsync());

                

                //Arrange
                var user = new User
                {
                    Id = 1,
                    Fullname = "test fullname",
                    Email = null,
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
                var repository = new UserRepository(context);
                repository.Add(user);

                //Assert
                var exception =
                    await Assert.ThrowsAsync<DbUpdateException>(() => repository.SaveChangesAsync());
                Assert.NotNull(exception);
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task DuplicatedPhoneNumberTest()
        {
            var connection = CreateSqLiteConnection();
            connection.Open();

            try
            {
                var options = SetDbContextOptionsBuilder(connection);

                await using var context = new DBContext(options);
                Assert.True(await context.Database.EnsureCreatedAsync());

                var userOne = new User
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

                var userTwo = new User
                {
                    Id = 2,
                    Fullname = "test fullname 2",
                    Email = "test2@example.com",
                    PhoneNumber = "11912581464",
                    Cep = "032132120",
                    Street = "Av Faria Lima 2",
                    AddressNumber = "123",
                    Complement = "casa 2",
                    District = "Itaim bibi 2",
                    State = "São Paulo 2",
                    City = "São Paulo 2",
                    Country = "Brasil 2",
                    Status = "CREATED",
                    CreatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811"),
                    UpdatedAt = DateTime.Parse("2023-08-24T00:17:47.1609811")
                };

                //Act
                var repository = new UserRepository(context);
                repository.Add(userOne);
                await repository.SaveChangesAsync();

                //Assert
                repository.Add(userTwo);
                var exception =
                    await Assert.ThrowsAsync<DbUpdateException>(() => repository.SaveChangesAsync());
                Assert.NotNull(exception);
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task CreateInvalidPhoneNumberTest()
        {
            var connection = CreateSqLiteConnection();
            connection.Open();

            try
            {
                var options = SetDbContextOptionsBuilder(connection);

                await using var context = new DBContext(options);
                Assert.True(await context.Database.EnsureCreatedAsync());

                

                //Arrange
                var user = new User
                {
                    Id = 1,
                    Fullname = "test fullname",
                    Email = "example@example.com",
                    PhoneNumber = null,
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
                var repository = new UserRepository(context);
                repository.Add(user);

                //Assert
                var exception =
                    await Assert.ThrowsAsync<DbUpdateException>(() => repository.SaveChangesAsync());
                Assert.NotNull(exception);
            }
            finally
            {
                connection.Close();
            }
        }

        private static DbContextOptions<DBContext> SetDbContextOptionsBuilder(DbConnection connection)
        {
            return new DbContextOptionsBuilder<DBContext>()
                .UseSqlite(connection)
                .Options;
        }

        private static SqliteConnection CreateSqLiteConnection()
        {
            return new SqliteConnection("DataSource=:memory:");
        }
    }
}