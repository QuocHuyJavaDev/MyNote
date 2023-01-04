using NoteApp.Models;
using NoteApp.UI.Mobile.ShellMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ViewModels
{
    public class NoteFavorVM
    {
        public Note noteFavor;
        public Note NoteFavorView
        {
            get => noteFavor;
        }

        public NoteFavorVM()
        {
            noteFavor = MbFavorDetail.createModel();
        }
    }
}
