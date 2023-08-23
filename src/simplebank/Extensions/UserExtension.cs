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
    }
}