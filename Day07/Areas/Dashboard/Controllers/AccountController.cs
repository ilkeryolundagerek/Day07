using AutoMapper;
using Day07.Areas.Dashboard.Services;
using Day07.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Day07.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<CustomUser> _userManager;
        private IMapper _mapper;

        public AccountController(UserManager<CustomUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(AccountService.Get().GetAccounts(_userManager, _mapper));
        }
    }
}
