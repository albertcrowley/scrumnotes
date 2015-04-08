using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S22.Imap;
using System.Net.Mail;
using System.Web;
using System.Net;


namespace ScrumNotes
{
    class Notes
    {
        string Server;
        string Email;
        string Password;
        ScrumNotesForm form;
        string htmlHead = "<html><head><style>.statusWrapper {display:block; padding-bottom: 1em;}  .who {font-weight:bold;}</style></head><body>";
        string htmlFoot = "</body></html>";

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
            List<MailMessage> emails = getEmails();


            notes.Append(htmlHead);
            foreach (MailMessage email in emails)
            {
                notes.Append(extractHTML(email));
            }
            notes.Append(htmlFoot);

            return notes.ToString(); ;
        }


        public string extractHTML(MailMessage mm)
        {
            StringBuilder html =  new StringBuilder();

            //WikiNetParser.WikiProvider.ConvertToHtml("test");

            html.Append("<div class='statusWrapper'>");
            html.Append("<div class='who'>" + WebUtility.HtmlEncode(mm.From.ToString()) + "</div>");
            html.Append("<div class='status'>" + WebUtility.HtmlEncode(mm.Body.ToString()) + "</div>");
            html.Append("</div>");
            return html.ToString();
        }

        public List<MailMessage> getEmails()
        {
            List<MailMessage> emails = new List<MailMessage>();

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
                        emails.Add(mm);
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
