using AutoMapper;
using Day07.Areas.Dashboard.Models;
using Day07.Entities;
using Microsoft.AspNetCore.Identity;

namespace Day07.Areas.Dashboard.Services
{
    public class AccountService
    {
        private static AccountService instance;

        private AccountService() { }

        public static AccountService Get()
        {
            instance ??= new AccountService();
            return instance;
        }

        public IEnumerable<AccountListItemViewModel> GetAccounts(UserManager<CustomUser> userManager, IMapper mapper)
        {
            return from u in userManager.Users
                   select mapper.Map<AccountListItemViewModel>(u);
        }
    }
}
