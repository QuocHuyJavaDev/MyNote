using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Service
{
    public interface IUser
    {
        Task<User> Login(string username, string password);
        Task<bool> Register(User user);
    }
}
