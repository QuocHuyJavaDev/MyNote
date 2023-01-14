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
    public class NoteVM : INote
    {
        //private string baseUrl = "http://192.168.124.54:6002/api/Note";
        private string baseUrl = "http://192.168.157.54:6002/api/Note";
        public async Task<bool> AddNote(Note note)
        {
            string json = JsonConvert.SerializeObject(note);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.157.54:6002/api/Note/addnote");
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

        public async Task<bool> DeleteNote(int noteid)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/delete/" + noteid);
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

        public async Task<bool> FavorChange(int noteid, Note note)
        {
            string json = JsonConvert.SerializeObject(note);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/favor/" + noteid);
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

        public async Task<List<Note>> GetByNtbId(int ntbid)
        {
            var note = new List<Note>();
            //
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/getbyntb/" + ntbid);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                note = await responseMessage.Content.ReadFromJsonAsync<List<Note>>();

            }
            return await Task.FromResult(note);
        }

        public async Task<List<Note>> GetByUserId(int userid)
        {
            var note = new List<Note>();
            //
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/getbyuser/" + userid);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                note = await responseMessage.Content.ReadFromJsonAsync<List<Note>>();

            }
            return await Task.FromResult(note);
        }

        public async Task<List<Note>> GetFavpr(int isfavor, int userid)
        {
            var note = new List<Note>();
            //
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/getfavor/" + isfavor + "/" + userid);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                note = await responseMessage.Content.ReadFromJsonAsync<List<Note>>();

            }
            return await Task.FromResult(note); 
        }

        public async Task<bool> UpdNote(int noteid, Note note)
        {
            string json = JsonConvert.SerializeObject(note);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/editnote/" + noteid);
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
