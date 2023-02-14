using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
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

        public Organizer GetOrganizer(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(OrganizerDTO organizerDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
