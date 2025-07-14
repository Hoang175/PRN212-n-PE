using DAL.Models;
using DAL.Repositories;

namespace BAL.Services
{
    public class UserAccountService
    {
        private readonly UserAccountRepository _repository = new();

        public UserAccount Login(string email, string password)
        {
            return _repository.Login(email, password);
        }
    }
}
