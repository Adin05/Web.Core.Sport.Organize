using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Web.Core.Sport.Organize.DTOs;
using Web.Core.Sport.Organize.Interfaces;
using Web.Core.Sport.Organize.Models;
using Web.Core.Sport.Organize.Services;

namespace Web.Core.Sport.Organize.Repositories
{
    public class SportEventRepositories : ISportEventRepositories
    {
        private readonly GlobalService _globalService;

        public SportEventRepositories(GlobalService globalService)
        {
            this._globalService = globalService;
        }
        public void Create(SportEventDTO SportEventDTO)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            var json = JsonConvert.SerializeObject(SportEventDTO, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.PostAsync("/api/v1/sport-events", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                OrganizerDTO? result = JsonConvert.DeserializeObject<OrganizerDTO>(data);
            }
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.DeleteAsync("/api/v1/sport-events/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
            }
        }

        public ResponseSportEventDTO GetSportEvent(int page, int perPage, int? organizerId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var path = "/api/v1/sport-events?page=" + page + "&perPage=" + perPage;
            if (organizerId != null) path += "&organizerId=" + organizerId;

            var response = client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                ResponseSportEventDTO? result = JsonConvert.DeserializeObject<ResponseSportEventDTO>(data);
                return result;
            }
            return null;
        }

        public SportEventDTO GetSportEvent(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.GetAsync("/api/v1/sport-events/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                SportEventDTO? result = JsonConvert.DeserializeObject<SportEventDTO>(data);
                result.OrganizerId = result.Organizer.ID;
                return result;
            }
            return null;
        }

        public void Update(SportEventDTO SportEventDTO)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            var json = JsonConvert.SerializeObject(SportEventDTO, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.PutAsync("/api/v1/sport-events/" + SportEventDTO.ID, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
