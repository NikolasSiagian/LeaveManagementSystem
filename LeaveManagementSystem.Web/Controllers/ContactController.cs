using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            var item = new ContactModel
            {
                Id = 1,
                Name = "Kolas"
            };
            return View(item);
        }
    }
}
