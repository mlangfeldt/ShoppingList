namespace ShoppingList.Models;

public class UserAccount //login and create user page
{
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string userKey { get; set; }//what's being used on web service

    public UserAccount(string username, string password, string email)
    {
        this.username = username;
        this.password = password;
    }

    public UserAccount(string userKey)
    {
        this.userKey = userKey;
    }
}