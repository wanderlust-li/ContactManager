using ContactManager.Data.Repository.IRepository;
using ContactManager.Models;

namespace ContactManager.Data.Repository;

public class ContactRepository : Repository<Contact>, IContactRepository
{
    private ApplicationDbContext _db;
    public ContactRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Contact obj)
    {
        _db.Contacts.Update(obj);
    }
}