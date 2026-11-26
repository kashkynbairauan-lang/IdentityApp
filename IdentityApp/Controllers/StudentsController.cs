using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    [Authorize] // Тек жүйеге кіргендер ғана кіре алады
    public class StudentsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // Барлық жүйеге кірген пайдаланушылар көре алады
        public IActionResult Index()
        {
            var students = _userManager.Users.ToList();
            return View(students);
        }

        // Тек Admin рөлі ғана жоя алады
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null && user.Email != "admin@example.com") // Өзін-өзі жойып алмас үшін
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}