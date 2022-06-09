namespace TestCodeSecurityReview.Interfaces;

public interface IUserService
{
    Task RegisterAsync();
    Task UpdateDataAsync(string userId);
}