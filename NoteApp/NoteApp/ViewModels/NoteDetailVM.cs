using NoteApp.Models;
using NoteApp.UI.Mobile.ShellMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ViewModels
{
    public class NoteDetailVM
    {
        public Note noteData;
        public Note NoteView
        {
            get => noteData;
        }

        public NoteDetailVM()
        {
            noteData = MbNDetail.createModel();
        }
        //
        

    }
}
