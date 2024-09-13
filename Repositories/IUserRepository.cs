using kme.Models.Users;

namespace kme.Repositories
{
    public interface IUserRepository : IRepository<User>
        {
            User WhereEmail(string email);
            IEnumerable<User> CheckLogin(string email, string password);
        }
    
}

