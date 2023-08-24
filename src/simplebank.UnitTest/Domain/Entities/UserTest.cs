using simplebank.Exceptions;
using simplebank.Extensions;

namespace simplebank.UnitTest.Domain.Entities
{
    public class UserTest
    {
        [Theory]
        [InlineData("1894@")]
        [InlineData("aaa@com.   ")]
        [InlineData("aaa@@.com   ")]
        [InlineData("aaa   @gmail.com")]
        [InlineData("aaa   @gmail")]
        [InlineData("aaa@gmail.com   ")]
        [InlineData("@gmail.com")]
        public void InvalidEmailFormatTest(string email)
        {
            var user = new User
            {
                Email = email
            };

            const string invalidEmailFormatErrorMessage = "The Email is not a valid e-mail address.";

            var exception = Assert.Throws<ValidationException>(user.ValidateEmail);
            Assert.Equal(invalidEmailFormatErrorMessage, exception.Message);
        }

        [Fact]
        public void EmailRequiredTest()
        {
            var user = new User
            {
                Email = string.Empty
            };

            const string emailRequiredErrorMessage = "The Email is required.";

            var exception = Assert.Throws<ValidationException>(() => user.ValidateEmail());
            Assert.Equal(emailRequiredErrorMessage, exception.Message);
        }

        [Fact]
        public void ValidEmailFormatTest()
        {
            var user = new User
            {
                Email = "example@example.com"
            };

            //Act
            var exception = Record.Exception(user.ValidateEmail);

            //Assert
            Assert.Null(exception);
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
        public void InvalidPhoneNumberFormatTest(string phoneNumber)
        {
            var user = new User
            {
                PhoneNumber = phoneNumber
            };

            const string invalidPhoneNumberFormatErrorMessage = "The Phone Number is not a valid phone number address.";

            var exception = Assert.Throws<ValidationException>(user.ValidatePhoneNumber);
            Assert.Equal(invalidPhoneNumberFormatErrorMessage, exception.Message);
        }

        [Fact]
        public void PhoneNumberRequiredTest()
        {
            var user = new User
            {
                PhoneNumber = string.Empty
            };

            const string phoneNumberRequiredErrorMessage = "The Phone Number is required.";

            var exception = Assert.Throws<ValidationException>(() => user.ValidatePhoneNumber());
            Assert.Equal(phoneNumberRequiredErrorMessage, exception.Message);
        }

        [Theory]
        [InlineData("11912581464")]
        [InlineData("     11912581464")]
        [InlineData("11912581464    ")]
        [InlineData("     11912581464     ")]
        [InlineData("(11)912581464")]
        [InlineData("(11) 912581464")]
        [InlineData("(11) 91258-1464")]
        [InlineData("(11) 91258 1464")]
        [InlineData("(11) 912581464   ")]
        [InlineData("    (11) 912581464")]
        [InlineData("    (11) 912581464   ")]
        [InlineData("11912581464a")]
        [InlineData("a11912581464")]
        [InlineData("a11912581464a")]
        [InlineData("  11912581464a")]
        [InlineData("  a11912581464")]
        [InlineData("  a11912581464a")]
        [InlineData("  11912581464a   ")]
        [InlineData("  a11912581464   ")]
        [InlineData("  a11912581464  a")]
        public void ValidPhoneNumberFormatTest(string PhoneNumber)
        {
            var user = new User
            {
                PhoneNumber = PhoneNumber
            };

            //Act
            var exception = Record.Exception(user.ValidatePhoneNumber);

            //Assert
            Assert.Null(exception);
        }

        [Fact]
        public void SetCreatedDate()
        {
            var user = new User();
            var actualDate = DateTime.Now;
            user.SetCreated();

            Assert.True(user.CreatedAt >= actualDate);
        }

        [Fact]
        public void SetUpdatedDate()
        {
            var user = new User();
            user.SetUpdate();

            Assert.NotNull(user.UpdatedAt);
        }
    }
}