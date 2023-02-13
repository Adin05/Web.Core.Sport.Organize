using System.Collections.Generic;
using System.Net.Http;
using System;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Interfaces;
using System.Text.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net.Http.Headers;

namespace Web.Core.Sport.Organize.Repositories
{
    public class AccountRepositories : IAccountRepositories
    {
        public UserDTO Login(string username, string password)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", username),
                new KeyValuePair<string, string>("password", password),
            });

            var response = client.PostAsync("/api/v1/users/login", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                LoginResponseDTO? user = JsonSerializer.Deserialize<LoginResponseDTO>(data);
                return getUserById(user.ID, user.Token);
            }
            return null;
        }

        public UserDTO getUserById(int id, string accessToken)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = client.GetAsync("/api/v1/users/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                UserDTO? user = JsonSerializer.Deserialize<UserDTO>(data);
                return user;
            }
            return null;
        }

        public UserDTO Register(RegisterDTO registerDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
