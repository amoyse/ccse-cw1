using Microsoft.AspNetCore.Components.Authorization;

namespace PacificTours.Client;

public class CustomAuthenticationStateProvider: AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        throw new NotImplementedException();
    }
}