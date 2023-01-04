using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Service
{
    public interface INotebook
    {
        Task<List<Notebook>> GetByUsId(int userid);
        Task<bool> AddNtb(Notebook ntb);
        Task<bool> UpdNtb(int ntbId, Notebook ntb);
        Task<bool> DeleteNtb(int ntbId);
    }
}
