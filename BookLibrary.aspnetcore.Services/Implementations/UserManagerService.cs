using System.Security.Claims;
using System.Threading.Tasks;
using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookLibrary.aspnetcore.Services.Implementations
{
    public class UserManagerService<TUser> : IUserManagerService<TUser> where TUser : ApplicationUser
    {
        private string _baseUrl;
        private string _apiName;

        public UserManagerService(string baseUrl, string apiName)
        {
            _baseUrl = baseUrl;
            _apiName = apiName;
        }

        public string GetUserName(ClaimsPrincipal principal)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = client.PostAsJsonAsync(_apiName + "GetUserName", principal).Result;
                return response.IsSuccessStatusCode ?  response.Content.ReadAsStringAsync().Result : string.Empty;
            }
        }

        public Task<IdentityResult> AddLoginAsync(TUser user, UserLoginInfo login)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> ConfirmEmailAsync(TUser user, string token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IdentityResult> CreateAsync(TUser user, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IdentityResult> CreateAsync(TUser user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = await client.PostAsJsonAsync(_apiName + "CreateAsync", user);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    var errors = result["errors"];
                    return result["succeeded"] as bool? == true ? IdentityResult.Success : IdentityResult.Failed();
                }
                else
                {
                    return IdentityResult.Failed();
                }
            }
        }

        public Task<TUser> FindByEmailAsync(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<TUser> FindByIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(TUser user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = await client.PostAsJsonAsync(_apiName + "GenerateEmailConfirmationTokenAsync", user);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : string.Empty;
            }
        }

        public Task<string> GeneratePasswordResetTokenAsync(TUser user)
        {
            throw new System.NotImplementedException();
        }

        public string GetUserId(ClaimsPrincipal principal)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsEmailConfirmedAsync(TUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword)
        {
            throw new System.NotImplementedException();
        }
    }
}
