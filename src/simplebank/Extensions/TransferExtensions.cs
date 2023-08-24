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

        public static void SetUpdate(this Transfer transfer)
        {
            transfer.UpdatedAt = DateTime.Now;
        }
    }
}