namespace TestCodeSecurityReview.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public string Password { get; set; }
    public string DisplayName { get; set; }
    public string BankAccountNumber { get; set; }
    public string SocialSecurityNumber { get; set; }
}