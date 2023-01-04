using Newtonsoft.Json;
using NoteApp.Models;
using NoteApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ViewModels
{
    public class UserVM : IUser
    {
        private string baseUrl = "http://192.168.1.8:6002/api/User";
        public async Task<User> Login(string username, string password)
        {
            var userInfor = new List<User>();
            //
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/" + username + "/" + password);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                string content = responseMessage.Content.ReadAsStringAsync().Result;
                userInfor = JsonConvert.DeserializeObject<List<User>>(content);
                return await Task.FromResult(userInfor.FirstOrDefault());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Register(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/register");
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
    }
}
