using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Gab;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods to add Gab authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class GabAuthenticationExtensions
    {
        /// <summary>
        /// Adds <see cref="GabAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Gab authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static AuthenticationBuilder AddGab(this AuthenticationBuilder builder)
        {
            return builder.AddGab(GabAuthenticationDefaults.AuthenticationScheme, options => { });
        }

        /// <summary>
        /// Adds <see cref="GabAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Gab authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="configuration">The delegate used to configure the OpenID 2.0 options.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static AuthenticationBuilder AddGab(this AuthenticationBuilder builder, Action<GabAuthenticationOptions> configuration)
        {
            return builder.AddGab(GabAuthenticationDefaults.AuthenticationScheme, configuration);
        }

        /// <summary>
        /// Adds <see cref="GabAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Gab authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="scheme">The authentication scheme associated with this instance.</param>
        /// <param name="configuration">The delegate used to configure the Gab options.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddGab(this AuthenticationBuilder builder, string scheme, Action<GabAuthenticationOptions> configuration)
        {
            return builder.AddGab(scheme, GabAuthenticationDefaults.DisplayName, configuration);
        }

        /// <summary>
        /// Adds <see cref="GabAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Gab authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="scheme">The authentication scheme associated with this instance.</param>
        /// <param name="caption">The optional display name associated with this instance.</param>
        /// <param name="configuration">The delegate used to configure the Gab options.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddGab(this AuthenticationBuilder builder, string scheme, string caption, Action<GabAuthenticationOptions> configuration)
        {
            return builder.AddOAuth<GabAuthenticationOptions, GabAuthenticationHandler>(scheme, caption, configuration);
        }
    }
}