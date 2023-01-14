using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Service
{
    public interface IUserDetail
    {
        Task<UserDetail> GetByUsId(int userid);
        Task<bool> AddInfor(UserDetail ud);
        Task<bool> EditInfor(int userid, UserDetail ud);
    }
}
