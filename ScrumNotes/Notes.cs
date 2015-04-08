using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22.Imap;
using System.Net.Mail;


namespace ScrumNotes
{
    class Notes
    {
        string Server;
        string Email;
        string Password;
        ScrumNotesForm form;

        /// <summary>
        /// Creates a Notes class
        /// </summary>
        /// <param name="server">server name</param>
        /// <param name="email">email address</param>
        /// <param name="password">email password</param>
        public Notes(ScrumNotesForm form)
        {
            this.form = form;
            Server = form.getServer();
            Email = form.getEmail();
            Password = form.getPassword();
        }


        public string getNotes()
        {
            StringBuilder notes = new StringBuilder();
            List<string> emails = getEmails();

            foreach (string email in emails)
            {
                notes.Append(extractHTML(email));
            }

            return notes.ToString(); ;
        }


        public string extractHTML(string bodyText)
        {
            return bodyText;
        }

        public List<string> getEmails()
        {
            List<string> emails = new List<string>();

            try
            {
                // Connect on port 993 using SSL.
                using (ImapClient client = new ImapClient(Server, 993, Email, Password, AuthMethod.Login, true))
                {
                    Console.WriteLine("We are connected!");

                    // Find messages that were sent from abc@def.com and have the string "Hello World" in their subject line.
                    IEnumerable<uint> uids = client.Search(
                        SearchCondition.Subject("scrum notes")
                    );

                    foreach (uint id in uids)
                    {
                        Console.WriteLine(id);
                        MailMessage mm = client.GetMessage(id);
                        emails.Add(mm.Body);
                    }
                }
            }
            catch (S22.Imap.InvalidCredentialsException ex)
            {
                form.setMessage(ToString());
            }
            return emails;
        }
    }

}
