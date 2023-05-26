namespace ContactManager.Data.Repository.IRepository;

public interface IUnitOfWork
{
    IContactRepository Contact { get; }
    void Save();
}