using SerwisTracker.Server.Database;

namespace SerwisTracker.Server.User
{
    public interface IUserRepository
    {
        ApplicationUser GetByName(string userName);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetByName(string userName)
        {
            return _context.Set<ApplicationUser>().SingleOrDefault(x => x.UserName == userName);
        }
    }
}
