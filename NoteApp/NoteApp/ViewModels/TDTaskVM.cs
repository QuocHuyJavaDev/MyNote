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
    public class TDTaskVM : ITDTask
    {
        private string baseUrl = "http://192.168.1.8:6002/api/TDTask";
        public async Task<bool> AddTask(TodoTask tdtask)
        {
            string json = JsonConvert.SerializeObject(tdtask);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/addtask");
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

        public async Task<bool> DeleteTask(int taskId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/delete/" + taskId);
            HttpResponseMessage responseMessage = await client.DeleteAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DoneChange(int taskid, TodoTask tdtask)
        {
            string json = JsonConvert.SerializeObject(tdtask);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/done/" + taskid);
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

        public async Task<List<TodoTask>> GetTask(int mainid)
        {
            var tdl = new List<TodoTask>();
            //
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/" + mainid);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                tdl = await responseMessage.Content.ReadFromJsonAsync<List<TodoTask>>();

            }
            return await Task.FromResult(tdl);
        }

        public async Task<bool> TaskNameChange(int taskid, TodoTask tdtask)
        {
            string json = JsonConvert.SerializeObject(tdtask);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/editname/" + taskid);
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
    }
}
