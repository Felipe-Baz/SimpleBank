using simplebank.Exceptions;
using simplebank.Extensions;

namespace simplebank.UnitTest.Domain.Entities
{
    public class TransferTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-12)]
        [InlineData(-124.3)]
        [InlineData(-0.12)]
        public void InvalidAmount(double amount)
        {
            var transfer = new Transfer
            {
                Amount = amount
            };

            const string invalidAmountErrorMessage = "The Amount must be greater than 0.";

            var exception = Assert.Throws<ValidationException>(transfer.ValidateAmount);
            Assert.Equal(invalidAmountErrorMessage, exception.Message);
        }

        [Fact]
        public void AmountRequiredTest()
        {
            var transfer = new Transfer
            {
                Amount = 0
            };

            const string amountRequiredErrorMessage = "The Amount is required.";

            var exception = Assert.Throws<ValidationException>(() => transfer.ValidateAmount());
            Assert.Equal(amountRequiredErrorMessage, exception.Message);
        }

        [Fact]
        public void ValidAmountTest()
        {
            var transfer = new Transfer
            {
                Amount = 12
            };

            //Act
            var exception = Record.Exception(transfer.ValidateAmount);

            //Assert
            Assert.Null(exception);
        }

        [Fact]
        public void FromUserRequidedErrorTest()
        {
            var transfer = new Transfer
            {
                ToUserId = 1
            };

            const string fromUserRequidedErrorMessage = "The From User is required.";

            //Act
            var exception = Record.Exception(transfer.ValidateFromTo);

            //Assert
            Assert.Equal(fromUserRequidedErrorMessage, exception.Message);
        }

        [Fact]
        public void ToUserRequidedErrorTest()
        {
            var transfer = new Transfer
            {
                FromUserId = 1
            };

            const string toUserRequidedErrorMessage = "The To User is required.";

            //Act
            var exception = Record.Exception(transfer.ValidateFromTo);

            //Assert
            Assert.Equal(toUserRequidedErrorMessage, exception.Message);
        }

        [Fact]
        public void InvalidFromToTest()
        {
            var transfer = new Transfer
            {
                FromUserId = 1,
                ToUserId = 1
            };

            const string invalidFromToErrorMessage = "The transfer must take place between 2 different users.";

            //Act
            var exception = Record.Exception(transfer.ValidateFromTo);

            //Assert
            Assert.Equal(invalidFromToErrorMessage, exception.Message);
        }

        [Fact]
        public void ValidFromToTest()
        {
            var transfer = new Transfer
            {
                FromUserId = 1,
                ToUserId = 2
            };

            //Act
            var exception = Record.Exception(transfer.ValidateFromTo);

            //Assert
            Assert.Null(exception);
        }

        [Fact]
        public void SetCreatedDate()
        {
            var transfer = new Transfer();
            var actualDate = DateTime.Now;
            transfer.SetCreated();

            Assert.True(transfer.CreatedAt >= actualDate);
        }
    }
}