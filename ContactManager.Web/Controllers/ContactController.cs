using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Web.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}