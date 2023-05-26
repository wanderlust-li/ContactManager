using ContactManager.Data;
using ContactManager.Data.Repository.IRepository;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Web.Controllers;

public class ContactController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    // GET
    // Отримує список всіх контактів з бази даних через IUnitOfWork і передає його в представлення "Index"
    public IActionResult Index()
    {
        List<Contact> contactList = _unitOfWork.Contact.GetAll().ToList();
        return View(contactList);
    }
    // Повертає представлення "Create", яке використовується для створення нового контакту
    public IActionResult Create()
    {
        return View();
    }

    // POST
    // переданий з форми, перевіряє його валідність, додає його до бази даних через IUnitOfWork та зберігає зміни. Потім перенаправляє на дію "Index"
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Contact.Add(contact);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        return View(contact);
    }
    
    // Отримує контакт з бази даних за заданим id через IUnitOfWork та повертає його в представлення "Delete" для підтвердження видалення
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
            return NotFound();

        Contact? contactFromDb = _unitOfWork.Contact.Get(u => u.Id == id);
        if (contactFromDb == null)
            return NotFound();

        return View(contactFromDb);
    }
    
    // POST
    
    //  Отримує контакт з бази даних за заданим id через IUnitOfWork, видаляє його та зберігає зміни. Потім перенаправляє на дію "Index"
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int ?id)
    {
        Contact? contactFromDb = _unitOfWork.Contact.Get(u => u.Id == id);

        if (contactFromDb == null)
            return NotFound();
        

        _unitOfWork.Contact.Remove(contactFromDb);
        _unitOfWork.Save();
        return RedirectToAction("Index");
    }
    // Отримує контакт з бази даних за заданим id через IUnitOfWork та повертає його в представлення "Edit" для редагування
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
            return NotFound();
        
        var contactFromDb = _unitOfWork.Contact.Get(u => u.Id == id);
        
        if (contactFromDb == null)
            return NotFound();

        return View(contactFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    // перевіряє Contact валідність, оновлює його дані в базі даних через IUnitOfWork та зберігає зміни. Потім перенаправляє на дію "Index"
    public IActionResult Edit(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Contact.Update(contact);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        return View(contact);
    }
}