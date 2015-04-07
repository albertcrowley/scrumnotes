using S22.Imap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumNotes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bGo_Click(object sender, EventArgs e)
        {

            // Connect on port 993 using SSL.
            using (ImapClient client = new ImapClient(tbServer.Text, 993, tbEmail.Text, tbPassword.Text,AuthMethod.Login,true))
            {
                Console.WriteLine("We are connected!");

                // Find messages that were sent from abc@def.com and have the string "Hello World" in their subject line.
                IEnumerable<uint> uids = client.Search(
                    SearchCondition.Subject("scrum notes")
                );

                foreach (uint id in uids)
                {
                    Console.WriteLine(id);
                    MailMessage mm= client.GetMessage(id);
                    rtbOutput.Text = mm.Body;
                }
            }

        }
    }
}
