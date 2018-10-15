using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Authentication
{
    public class GabAuthenticationHttpClientHandler : DelegatingHandler
    {
        private readonly string _token;

        public GabAuthenticationHttpClientHandler(IServiceProvider services, IHttpContextAccessor accessor)
        {
            var userManager = services.CreateScope().ServiceProvider.GetService<UserManager<IdentityUser>>();
            var user = userManager.Users.SingleOrDefault(x => x.UserName == accessor.HttpContext.User.Identity.Name);
            _token = userManager.GetAuthenticationTokenAsync(user, "Gab", "access_token").Result;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            return base.SendAsync(request, cancellationToken);
        }
    }
}