using System.Collections;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace PacificTours.Client;


public class CustomAuthenticationStateProvider: AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {

        var httpClient = new HttpClient();

        Console.WriteLine("test");
        // var authUser = JsonSerializer.Deserialize<IEnumerable<Claim>>(await httpClient.GetStringAsync(("https://localhost:7293/api/Auth")));
        var userName = await httpClient.GetStringAsync("https://localhost:7293/api/Auth");
        Console.WriteLine(userName);
        
        var identity = new ClaimsIdentity(userName);
        
        var user = new ClaimsPrincipal(identity);

        return await Task.FromResult(new AuthenticationState(user));


        // var user = await 
    }
}