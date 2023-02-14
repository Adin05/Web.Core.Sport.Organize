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
    public class OrganizerRepositories : IOrganizerRepositories
    {
        private readonly GlobalService _globalService;

        public OrganizerRepositories(GlobalService globalService)
        {
            this._globalService = globalService;
        }
        public void Create(OrganizerDTO organizerDTO)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            var json = JsonConvert.SerializeObject(organizerDTO, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.PostAsync("/api/v1/organizers", content).Result;
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

            var response = client.DeleteAsync("/api/v1/organizers/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
            }
        }

        public ResponseOrganizerDTO GetOrganizers(int page, int perPage)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.GetAsync("/api/v1/organizers?page=" + page + "&perPage=" + perPage).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                ResponseOrganizerDTO? result = JsonConvert.DeserializeObject<ResponseOrganizerDTO>(data);
                return result;
            }
            return null;
        }

        public OrganizerDTO GetOrganizer(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.GetAsync("/api/v1/organizers/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                OrganizerDTO? result = JsonConvert.DeserializeObject<OrganizerDTO>(data);
                return result;
            }
            return null;
        }

        public void Update(OrganizerDTO organizerDTO)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            var json = JsonConvert.SerializeObject(organizerDTO, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.PutAsync("/api/v1/organizers/" + organizerDTO.ID, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
