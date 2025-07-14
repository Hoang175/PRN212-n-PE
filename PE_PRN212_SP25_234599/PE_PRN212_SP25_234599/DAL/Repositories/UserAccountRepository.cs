using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserAccountRepository
    {
        private readonly Sp25researchDbContext _context = new();

        public UserAccount Login(string email, string password)
        {
            return _context.UserAccounts.AsNoTracking().FirstOrDefault(x => x.Email == email && 
                                                                            x.Password == password &&
                                                                            (x.Role == 2 || x.Role == 3));
        }
    }
}
