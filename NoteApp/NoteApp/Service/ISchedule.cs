using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Service
{
    public interface ISchedule
    {
        Task<List<Schedule>> GetScheList(int userid);
        Task<bool> AddSche(Schedule sche);
        Task<bool> EditSche(int scheid, Schedule sche);
    }
}
