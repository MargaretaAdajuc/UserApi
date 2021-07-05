using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.IUserRepository;

namespace DataAccess.EFCore
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<User> GetPopularUsers(int count)
        {
            return _context.Users.OrderByDescending(d => d.Followers).Take(count).ToList();
        }
    }
}
