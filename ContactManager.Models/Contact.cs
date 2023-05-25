using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models;

public class Contact
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
}