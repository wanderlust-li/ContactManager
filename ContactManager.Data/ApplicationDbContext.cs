using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data;

public class ApplicationDbContext : DbContext // DbContext - надає функціональність для роботи з базою даних в EF Core.
{
    public ApplicationDbContext()
    {
    }

    // конструктор, для налаштуваггя контексту
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ContentManager;Trusted_Connection=True;");
    }

    // колекція в бд, яка дозволяє взаємодіяти за допомогою EF Core
    public DbSet<Contact> Contacts { get; set; }

    // налаштовуємо модель бази даних
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // встановлюємо дані
        modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = 1, Name = "Yevhenii", Surname = "Lichman", Email = "yevhenii@gmail.com",
                PhoneNumber = "9999999"
            });
    }
}