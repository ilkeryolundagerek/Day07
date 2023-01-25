using AutoMapper;
using Day07.Areas.Dashboard.Services;
using Day07.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Configuration;
using System.Net.WebSockets;

namespace Day07.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<CustomUser> _userManager;
        private RoleManager<CustomRole> _roleManager;
        private IMapper _mapper;

        public AccountController(UserManager<CustomUser> userManager, IMapper mapper, RoleManager<CustomRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(AccountService.Get().GetAccounts(_userManager, _mapper));
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id.Equals(id));
            var userRoles = await _userManager.GetRolesAsync(user);
            ViewBag.Roles = _roleManager.Roles.Select(x => new SelectListItem()
            {
                Value = x.Name,
                Text = x.Name,
                Selected = userRoles.Contains(x.Name)
            });
            return View(_userManager.Users.FirstOrDefault(x => x.Id.Equals(id)));
        }

        public bool Toggle(string p, string id)
        {
            bool result = false;
            var selectedUser = _userManager.Users.FirstOrDefault(x => x.Id.Equals(id));
            switch (p)
            {
                case "active":
                    selectedUser.Active = !selectedUser.Active;
                    result = selectedUser.Active;
                    break;
                case "deleted":
                    selectedUser.Deleted = !selectedUser.Deleted;
                    result = selectedUser.Deleted;
                    break;
                case "email_confirmed":
                    selectedUser.EmailConfirmed = !selectedUser.EmailConfirmed;
                    result = selectedUser.EmailConfirmed;
                    break;
                case "phone_number_confirmed":
                    selectedUser.PhoneNumberConfirmed = !selectedUser.PhoneNumberConfirmed;
                    result = selectedUser.PhoneNumberConfirmed;
                    break;
                case "two_factor_enabled":
                    selectedUser.TwoFactorEnabled = !selectedUser.TwoFactorEnabled;
                    result = selectedUser.TwoFactorEnabled;
                    break;
                case "lockout_enabled":
                    selectedUser.LockoutEnabled = !selectedUser.LockoutEnabled;
                    result = selectedUser.LockoutEnabled;
                    break;
            }
            _userManager.UpdateAsync(selectedUser);

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string id, string role)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id.Equals(id));
            if (user != null)
            {
                if (await _userManager.IsInRoleAsync(user, role))
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
            }

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
