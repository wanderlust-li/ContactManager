using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ContentManager;Trusted_Connection=True;");
    }
    
    public DbSet<Contact> Contacts { get; set; }
}