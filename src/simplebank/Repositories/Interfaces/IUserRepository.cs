using simplebank.Model;

namespace simplebank.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByFilterAsync(UserFilter filter);
        Task<List<User>> GetListByFilterAsync(UserFilter filter);
        
        public User GetUserByIdWithDeleted(int userId);
    }
}