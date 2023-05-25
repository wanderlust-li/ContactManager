using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Web.Controllers;

public class ContactController : Controller
{
    private readonly ApplicationDbContext _context;

    public ContactController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        IEnumerable<Contact> allContacts = _context.Contacts;

        return View(allContacts);
    }
}