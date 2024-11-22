using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoppingList.Models;

namespace ShoppingList.Views;

public partial class NewAccountPage : ContentPage
{
    public NewAccountPage()
    {
        InitializeComponent();
        Title = "Create New Account";
    }

    async void CreateAccount_OnClicked(object sender, EventArgs e)
    //do passwords match
    
    //is the email address valid = @ and .
    
    
    {
        //API stuff
        var data = JsonConvert.SerializeObject(new UserAccount(txtUser.Text, txtPassword1.Text, txtEmail.Text));
        var client = new HttpClient();
        var response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/createuser"), new StringContent(data,Encoding.UTF8,"application/json"));

        var AccountStatus = response.Content.ReadAsStringAsync().Result;
       
        //does user exist
        if (AccountStatus == "user exists")
        {
            await DisplayAlert("Error", "Sorry, this username is taken", "OK");
            return;
        }
        
        //is email in use
        if (AccountStatus == "email exists")
        {
            await DisplayAlert("Error", "Sorry, this email is already in use", "OK");
            return;
        }
        
        if (AccountStatus == "complete")
        {
            response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/login"), new StringContent(data,Encoding.UTF8,"application/json"));

            var SKey = response.Content.ReadAsStringAsync().Result;//if get valid key, logged in
            if (!string.IsNullOrEmpty(SKey) && SKey.Length <50 )
            {
                App.SessionKey = "SKey";
                Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "Sorry, there was an issue logging you in", "OK");
                return;
            }
        }
        else
        {
            await DisplayAlert("Error", "Sorry, an error occured creating your account", "OK");
            return; 
        }
        
    }
}