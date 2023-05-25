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
    public IActionResult Create()
    {
        return View();
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(contact);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
            return NotFound();

        Contact? contactFromDb = _context.Contacts.FirstOrDefault(u => u.Id == id);
        if (contactFromDb == null)
            return NotFound();

        return View(contactFromDb);
    }
    
    // POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int ?id)
    {
        Contact? contactFromDb = _context.Contacts.FirstOrDefault(u => u.Id == id);

        if (contactFromDb == null)
            return NotFound();
        

        _context.Contacts.Remove(contactFromDb);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}