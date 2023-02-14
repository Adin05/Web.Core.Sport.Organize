using System.Collections.Generic;
using System.Net.Http;
using System;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Interfaces;
using System.Text.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Web.Core.Sport.Organize.Repositories
{
    public class AccountRepositories : IAccountRepositories
    {
        public async Task<UserDTO> Login(string username, string password)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", username),
                new KeyValuePair<string, string>("password", password),
            });

            var response = await client.PostAsync("/api/v1/users/login", content);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                LoginResponseDTO? user = JsonConvert.DeserializeObject<LoginResponseDTO>(data);
                return await getUserById(user.ID, user.Token);
            }
            return null;
        }

        public async Task<UserDTO> getUserById(int id, string accessToken)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync("/api/v1/users/" + id);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                UserDTO? user = JsonConvert.DeserializeObject<UserDTO>(data);
                user.Token = accessToken;
                return user;
            }
            return null;
        }

        public async Task<RegisterResponseDTO> Register(RegisterDTO registerDTO)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            var json = JsonConvert.SerializeObject(registerDTO, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/v1/users", content);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                RegisterResponseDTO? reg = JsonConvert.DeserializeObject<RegisterResponseDTO>(data);
                return reg;
            }
            return null;
        }
    }
}
