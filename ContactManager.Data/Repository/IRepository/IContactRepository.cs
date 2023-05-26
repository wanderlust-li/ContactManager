using ContactManager.Models;

namespace ContactManager.Data.Repository.IRepository;

public interface IContactRepository :IRepository<Contact>
{
    void Update(Contact obj);
}