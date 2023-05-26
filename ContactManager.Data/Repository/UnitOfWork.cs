using ContactManager.Data.Repository.IRepository;

namespace ContactManager.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    public IContactRepository Contact { get; private set; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Contact = new ContactRepository(_db);
    }
    
    public void Save()
    {
        _db.SaveChanges();
    }
}