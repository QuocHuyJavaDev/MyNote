using Newtonsoft.Json;
using NoteApp.Models;
using NoteApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ViewModels
{
    public class NotebookVM : INotebook
    {
        #region Properities
        //List luu cac NTB
        public ObservableCollection<Notebook> ntbList { get; set; } = new ObservableCollection<Notebook>();
        #endregion
        public NotebookVM() { NtbList(); }
        //
        private async void NtbList()
        {
            ntbList.Clear();
            int userid = App.userInfor.UserId;
            List<Notebook> list = await GetByUsId(userid);
            for (int i = list.Count-1; i >= 0; i--)
            {
                ntbList.Add(list[i]);
            }
            sortList();
        }
        private void sortList()
        {
            for (int i = 0; i < ntbList.Count-1; i++)
            {
                for (int j = i; j< ntbList.Count; j++) 
                {
                    if (ntbList[i].NotebookId < ntbList[j].NotebookId)
                    {
                        Notebook temp = ntbList[i];
                        ntbList[i] = ntbList[j];
                        ntbList[j] = temp;
                    }
                }
            }
        }
        private string baseUrl = "http://192.168.1.8:6002/api/Ntb";
        public async Task<bool> AddNtb(Notebook ntb)
        {
            string json = JsonConvert.SerializeObject(ntb);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/addntb");
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

        public async Task<List<Notebook>> GetByUsId(int userid)
        {
            var ntb = new List<Notebook>();
            //
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/" + userid);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                ntb = await responseMessage.Content.ReadFromJsonAsync<List<Notebook>>();

            }
            return await Task.FromResult(ntb);
        }

        public async Task<bool> UpdNtb(int ntbId, Notebook ntb)
        {
            string json = JsonConvert.SerializeObject(ntb);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/" + ntbId);
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

        public async Task<bool> DeleteNtb(int ntbId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl + "/delete/" + ntbId);
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
    }
}
