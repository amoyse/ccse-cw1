using System.Collections;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using String = System.String;

namespace PacificTours.Client;


public class CustomAuthenticationStateProvider: AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {

        var httpClient = new HttpClient();

        var userDictString = await httpClient.GetStringAsync("https://localhost:7293/api/Auth/GetAuthState");
        
        var userId = "";
        var userName = "";

        if (userDictString != "User is not signed in.")
        {
            var dictionary = JsonSerializer.Deserialize<Dictionary<String, String>>(userDictString);
            
            userId = dictionary["userId"];
            userName = dictionary["userName"];
            
        }
        
        var identity = new ClaimsIdentity(new []
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, userName),
        }, "My username and id auth type");
        
        var user = new ClaimsPrincipal(identity);
        
        return await Task.FromResult(new AuthenticationState(user));
    }
}