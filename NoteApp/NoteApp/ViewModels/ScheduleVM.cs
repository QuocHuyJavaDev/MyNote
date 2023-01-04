using Newtonsoft.Json;
using NoteApp.Models;
using NoteApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ViewModels
{
    public class ScheduleVM : ISchedule
    {
        private string baseUrl = "http://192.168.1.8:6002/api/Schedule";
        public async Task<bool> AddSche(Schedule sche)
        {
            string json = JsonConvert.SerializeObject(sche);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/addsche");
            HttpResponseMessage responseMessage = await client.PostAsync("", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EditSche(int scheid, Schedule sche)
        {
            string json = JsonConvert.SerializeObject(sche);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/editsche/" + scheid);
            HttpResponseMessage responseMessage = await client.PutAsync("", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Schedule>> GetScheList(int userid)
        {
            var sche = new List<Schedule>();
            //
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/sche/" + userid);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                sche = await responseMessage.Content.ReadFromJsonAsync<List<Schedule>>();

            }
            return await Task.FromResult(sche);
        }
    }
}
