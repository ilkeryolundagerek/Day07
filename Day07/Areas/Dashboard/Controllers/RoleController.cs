using Day07.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Day07.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class RoleController : Controller
    {
        private UserManager<CustomUser> _userManager;
        private RoleManager<CustomRole> _roleManager;
        private IRoleStore<CustomRole> _roleStore;

        public RoleController(UserManager<CustomUser> userManager, RoleManager<CustomRole> roleManager, IRoleStore<CustomRole> roleStore)
        {
            _userManager = userManager;
            _roleManager = roleManager;            _roleStore = roleStore;

        }

        // GET: RoleController
        public ActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        // GET: RoleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Name)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                CustomRole role = Activator.CreateInstance<CustomRole>();
                await _roleStore.SetRoleNameAsync(role, Name, CancellationToken.None);
                try
                {
                    await _roleManager.CreateAsync(role);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(role);
                }
            }
            return View();
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
