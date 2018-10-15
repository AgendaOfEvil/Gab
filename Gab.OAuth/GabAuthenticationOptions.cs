using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Authentication.Gab
{
    /// <inheritdoc />
    /// <summary>
    /// Defines a set of options used by <see cref="T:AspNet.Security.OAuth.Gab.GabAuthenticationHandler" />.
    /// </summary>
    public class GabAuthenticationOptions : OAuthOptions
    {
        public GabAuthenticationOptions()
        {
            ClaimsIssuer = GabAuthenticationDefaults.Issuer; 
            CallbackPath = new PathString(GabAuthenticationDefaults.CallbackPath);
            AuthorizationEndpoint = GabAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = GabAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = GabAuthenticationDefaults.UserInformationEndpoint;

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimActions.MapJsonKey(ClaimTypes.Name, "username");
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email"); 
        }
    }
}