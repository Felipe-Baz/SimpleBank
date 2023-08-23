using simplebank.Data;
using simplebank.Model;
using simplebank.Repositories.Interfaces;

namespace simplebank.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {
        }

        
    }
}