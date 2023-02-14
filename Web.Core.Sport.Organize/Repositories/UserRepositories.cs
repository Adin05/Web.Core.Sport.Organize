using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Interfaces;
using Web.Core.Sport.Organize.Models;
using Web.Core.Sport.Organize.Services;

namespace Web.Core.Sport.Organize.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly GlobalService _globalService;

        public UserRepositories(GlobalService globalService)
        {
            this._globalService = globalService;
        }

        public void ChangePassword(ChangePasswordDTO userDTO)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            var json = JsonConvert.SerializeObject(userDTO, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.PutAsync("/api/v1/users/" + _globalService.UserId + "/password", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
            }
        }


        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.DeleteAsync("/api/v1/users/" + _globalService.UserId).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
            }
        }

        public UserDTO GetUser(int id, string accessToken)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = client.GetAsync("/api/v1/users/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                UserDTO? user = JsonConvert.DeserializeObject<UserDTO>(data);
                return user;
            }
            return null;
        }

        public void Update(UserDTO userDTO)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            var json = JsonConvert.SerializeObject(userDTO, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.PutAsync("/api/v1/users/" + _globalService.UserId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
