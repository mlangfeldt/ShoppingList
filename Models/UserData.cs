namespace ShoppingList.Models;

public class UserDataCollection 
{
public UserData[] UserDataItems { get; set; }
}

public class UserData
{
   public string dataID { get; set; }
   public string dataValue { get; set; }
   public string userKey { get; set; }

   public UserData(string dataId, string dataValue, string userKey)
   {
      this.dataID = dataId;
      this.dataValue = dataValue;
      this.userKey = userKey;
   }
}