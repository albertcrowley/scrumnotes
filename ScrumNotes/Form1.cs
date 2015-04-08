using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumNotes
{
    public partial class ScrumNotesForm : Form
    {
        public ScrumNotesForm()
        {
            InitializeComponent();
        }

        private void bGo_Click(object sender, EventArgs e)
        {
            Notes notes = new Notes(this);
            string s = notes.getNotes();
            webBrowser1.DocumentText = s;
            Drive drive = new Drive();
            drive.saveNotes(s);
        }

        public string getServer() { return tbServer.Text; }
        public string getEmail() { return tbEmail.Text; }
        public string getPassword() { return tbPassword.Text; }
        public void setMessage(string msg) { webBrowser1.DocumentText = msg; }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                bGo_Click(sender, null);
            }
        }
    }
}
