using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Authfix.Blazor.Extensions.Oidc
{
    public class UserManager
    {
        /// <summary>
        /// Initialize a user manager
        /// </summary>
        /// <param name="identityConfiguration">The configuration for this user manager</param>
        public UserManager(IdentityConfiguration identityConfiguration)
        {
            if(identityConfiguration == null)
            {
                throw new ArgumentNullException(nameof(identityConfiguration));
            }

            JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.Init", new DotNetObjectRef(identityConfiguration));
        }

        /// <summary>
        /// Clear the stale state
        /// </summary>
        /// <returns></returns>
        public Task ClearStaleState()
        {
            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.ClearStaleState");
        }

        /// <summary>
        /// Get authenticated user
        /// </summary>
        /// <returns>If there is no authenticated user, return null. Else, return the current authenticated user</returns>
        public Task<IdentityUser> GetUser()
        {
            return JSRuntime.Current.InvokeAsync<IdentityUser>("Authfix.Blazor.Extensions.Oidc.GetUser");
        }

        /// <summary>
        /// Store a user inside the storage
        /// </summary>
        /// <param name="userToStore">The user to store</param>
        /// <returns></returns>
        public Task StoreUser(IdentityUser userToStore)
        {
            if (userToStore == null)
            {
                throw new ArgumentNullException(nameof(userToStore));
            }

            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.StoreUser", new DotNetObjectRef(userToStore));
        }

        /// <summary>
        /// Remove the current user from the storage
        /// </summary>
        /// <returns></returns>
        public Task RemoveUser()
        {
            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.RemoveUser");
        }

        /// <summary>
        /// Display the sign in popup
        /// </summary>
        /// <returns></returns>
        public Task<IdentityUser> SignInPopup()
        {
            return JSRuntime.Current.InvokeAsync<IdentityUser>("Authfix.Blazor.Extensions.Oidc.SignInPopup");
        }

        /// <summary>
        /// Execute the popup callback
        /// </summary>
        /// <param name="url">The callback url</param>
        /// <returns></returns>
        public Task SignInPopupCallback(string url = null)
        {
            if(string.IsNullOrEmpty(url))
                return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.SignInPopupCallback");

            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.SignInPopupCallback", url);
        }

        /// <summary>
        /// Execute the sign in silently
        /// </summary>
        /// <returns></returns>
        public Task<IdentityUser> SignInSilent()
        {
            return JSRuntime.Current.InvokeAsync<IdentityUser>("Authfix.Blazor.Extensions.Oidc.SignInSilent");
        }

        /// <summary>
        /// Execute the sign in silently callback
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task SignInSilentCallback(string url = null)
        {
            if(string.IsNullOrEmpty(url))
                return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.SignInSilentCallback");

            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.SignInSilentCallback", new DotNetObjectRef(url));
        }

        /// <summary>
        /// Execute the sign in redirection to third party identity server
        /// </summary>
        /// <returns></returns>
        public Task SignInRedirect()
        {
            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.SignInRedirect");
        }

        /// <summary>
        /// Execute the sign in redirection callback from the third party identity server
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<IdentityUser> SignInRedirectCallback(string url = null)
        {
            if(string.IsNullOrEmpty(url))
                return JSRuntime.Current.InvokeAsync<IdentityUser>("Authfix.Blazor.Extensions.Oidc.SignInRedirectCallback");

            return JSRuntime.Current.InvokeAsync<IdentityUser>("Authfix.Blazor.Extensions.Oidc.SignInRedirectCallback", new DotNetObjectRef(url));
        }

        /// <summary>
        /// Display the sign out popup
        /// </summary>
        /// <returns></returns>
        public Task SignOutPopup()
        {
            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.SignOutPopup");
        }

        /// <summary>
        /// Execute the sign out popup callback
        /// </summary>
        /// <param name="url">The redirect url</param>
        /// <param name="keepOpen">If we keep open</param>
        /// <returns></returns>
        public Task SignOutPopupCallback(bool keepOpen = false, string url = null)
        {
            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.SignOutPopupCallback", new DotNetObjectRef(url), new DotNetObjectRef(keepOpen));
        }

        /// <summary>
        /// Query the session status
        /// </summary>
        /// <returns></returns>
        public Task QuerySessionStatus()
        {
            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.QuerySessionStatus");
        }

        /// <summary>
        /// Revoke the current access token
        /// </summary>
        /// <returns></returns>
        public Task RevokeAccessToken()
        {
            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.RevokeAccessToken");
        }

        /// <summary>
        /// Start the silent renew process
        /// </summary>
        /// <returns></returns>
        public Task StartSilentRenew()
        {
            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.StartSilentRenew");
        }

        /// <summary>
        /// Stop the silent renew process
        /// </summary>
        /// <returns></returns>
        public Task StopSilentRenew()
        {
            return JSRuntime.Current.InvokeAsync<object>("Authfix.Blazor.Extensions.Oidc.StopSilentRenew");
        }
    }
}
