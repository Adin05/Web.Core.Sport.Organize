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
    public class SportEventRepositories : ISportEventRepositories
    {
        private readonly GlobalService _globalService;

        public SportEventRepositories(GlobalService globalService)
        {
            this._globalService = globalService;
        }
        public void Create(SportEventDTO SportEventDTO)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public ResponseSportEventDTO GetSportEvent(int page, int perPage)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-sport-events.php6-02.test.voxteneo.com/");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _globalService.Token);

            var response = client.GetAsync("/api/v1/organizers?page=" + page + "&perPage=" + perPage).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                ResponseSportEventDTO? result = JsonConvert.DeserializeObject<ResponseSportEventDTO>(data);
                return result;
            }
            return null;
        }

        public SportEvent GetSportEvent(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(SportEventDTO SportEventDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
