using Microsoft.EntityFrameworkCore;
using simplebank.Data;
using simplebank.Model;
using simplebank.Repositories.Interfaces;

namespace simplebank.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DBContext context) : base(context)
        {
        }

        public async Task<User> GetByFilterAsync(UserFilter filter)
        {
            var query = DbContext.Users.AsQueryable();

            query = ApplyFilter(filter, query);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetListByFilterAsync(UserFilter filter)
        {
            var query = DbContext.Users.AsQueryable();

            query = ApplyFilter(filter, query);

            query = ApplySorting(filter, query);

            return await query.ToListAsync();
        }

        public User GetUserByIdWithDeleted(int userId)
        {
            var user = DbContext.GetUserByIdWithDeleted(userId);
            return user;
        }

        private static IQueryable<User> ApplyFilter(UserFilter filter,
        IQueryable<User> query)
        {
            if (filter.Id > 0)
                query = query.Where(x => x.Id == filter.Id);

            if (!string.IsNullOrWhiteSpace(filter.Email))
                query = query.Where(x => EF.Functions.Like(x.Email, $"%{filter.Email}%"));

            if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
                query = query.Where(x => EF.Functions.Like(x.PhoneNumber, $"%{filter.PhoneNumber}%"));

            return query;
        }

        private static IQueryable<User> ApplySorting(UserFilter filter,
        IQueryable<User> query)
        {
            query = filter?.OrderBy.ToLower() switch
            {
                "fullname" => filter.SortBy.ToLower() == "asc"
                    ? query.OrderBy(x => x.Fullname)
                    : query.OrderByDescending(x => x.Fullname),
                "phoneNumber" => filter.SortBy.ToLower() == "asc"
                    ? query.OrderBy(x => x.PhoneNumber)
                    : query.OrderByDescending(x => x.PhoneNumber),
                "email" => filter.SortBy.ToLower() == "asc"
                    ? query.OrderBy(x => x.Email)
                    : query.OrderByDescending(x => x.Email),
                _ => query
            };

            return query;
        }

    }
}