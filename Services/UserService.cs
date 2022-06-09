using System.Data;
using System.Data.SqlClient;
using Dapper;
using TestCodeSecurityReview.Interfaces;
using TestCodeSecurityReview.Models;

namespace TestCodeSecurityReview.Services;

public class UserService : IUserService
{
    public async Task RegisterAsync()
    {
        using (var db = new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"))
        {
            var user = new User
            {
                Username = "putuprema",
                Password = "123456",
                DisplayName = "Putu",
                BankAccountNumber = "13719713158835300",
                SocialSecurityNumber = "078051121" 
            };

            await db.ExecuteAsync(
                "INSERT INTO users (Username, Password, DisplayName, BankAccountNumber, SocialSecurityNumber) VALUES (@Username, @Password, @DisplayName, @BankAccountNumber, @SocialSecurityNumber)",
                user);
        }
    }

    public async Task UpdateDataAsync(string userId)
    {
        using var db =
            new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");

        var user = await db.QueryFirstAsync<User>("SELECT * FROM User WHERE Id = '" + userId + "'");
        user.BankAccountNumber = "71086643758945400";

        await db.ExecuteAsync("sp_UpdateUser", user, commandType: CommandType.StoredProcedure);
    }
}