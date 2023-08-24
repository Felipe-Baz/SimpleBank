using System.Text.RegularExpressions;
using simplebank.Exceptions;
using simplebank.Model;

namespace simplebank.Extensions
{
    public static class UserExtension
    {
        public static void SetCreated(this User user)
        {
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
        }

        public static void SetUpdate(this User user)
        {
            user.UpdatedAt = DateTime.Now;
        }

        public static void ValidateEmail(this User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ValidationException("The Email is required.");

            if (!Regex.IsMatch(user.Email,
                    @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                    RegexOptions.IgnoreCase))
                throw new ValidationException("The Email is not a valid e-mail address.");
        }

        public static void ValidatePhoneNumber(this User user)
        {
            if (string.IsNullOrWhiteSpace(user.PhoneNumber))
                throw new ValidationException("The Phone Number is required.");

            // Remova quaisquer caracteres não numéricos do número de telefone
            string cleanedPhoneNumber = Regex.Replace(user.PhoneNumber, "[^0-9]", "");

            // Defina um comprimento mínimo para um número de telefone válido (por exemplo, 10 dígitos)
            int minPhoneNumberLength = 10;

            if (cleanedPhoneNumber.Length != 11 || cleanedPhoneNumber.Length < minPhoneNumberLength)
                throw new ValidationException("The Phone Number is not a valid phone number address.");
        }
    }
}