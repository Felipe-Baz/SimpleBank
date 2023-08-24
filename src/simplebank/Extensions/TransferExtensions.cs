using simplebank.Exceptions;
using simplebank.Model;

namespace simplebank.Extensions
{
    public static class TransferExtensions
    {
        public static void SetCreated(this Transfer transfer)
        {
            transfer.CreatedAt = DateTime.Now;
            transfer.UpdatedAt = DateTime.Now;
        }

        public static void ValidateAmount(this Transfer transfer)
        {
            if (transfer.Amount == 0)
                throw new ValidationException("The Amount is required.");
            

            if (transfer.Amount < 0)
                throw new ValidationException("The Amount must be greater than 0.");
        }

        public static void ValidateFromTo(this Transfer transfer)
        {
            if (transfer.FromUserId == 0)
                throw new ValidationException("The From User is required.");
            
            if (transfer.ToUserId == 0)
                throw new ValidationException("The To User is required.");
            
            if (transfer.FromUserId == transfer.ToUserId)
                throw new ValidationException("The transfer must take place between 2 different users.");
        }
    }
}