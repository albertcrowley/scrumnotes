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
        string subject = "scrum notes";
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

            WikiPlex.WikiEngine wEngine = new WikiPlex.WikiEngine();

            


            html.Append("<div class='statusWrapper'>");
            html.Append("<div class='who'>" + WebUtility.HtmlEncode(mm.From.ToString()) + "</div>");
            html.Append("<div class='status'>" + wEngine.Render(mm.Body.ToString()) + "</div>");
            html.Append("</div>");
            return html.ToString();
        }

        public List<MailMessage> getEmails()
        {
            Dictionary<string, MailMessage> emails = new Dictionary<string, MailMessage>();  // used to keep just the newest from each user

            try
            {
                // Connect on port 993 using SSL.
                using (ImapClient client = new ImapClient(Server, 993, Email, Password, AuthMethod.Login, true))
                {

                    DateTime time = DateTime.Now.AddHours(-24);
                    IEnumerable<uint> uids = client.Search(
                        SearchCondition.Subject(subject).And(SearchCondition.SentSince(time))
                    );

                    foreach (uint id in uids)
                    {
                        Console.WriteLine(id);
                        MailMessage mm = client.GetMessage(id);
                        string from = mm.From.ToString();
                        if (emails.ContainsKey(from))
                        {
                            MailMessage existingMM = emails[from];
                            if (existingMM.Date() < mm.Date())
                            {
                                emails[from] = mm;
                            }
                        }
                        else
                        {
                            emails[from] = mm;
                        }
                    }
                }
            }
            catch (S22.Imap.InvalidCredentialsException ex)
            {
                form.setMessage(ToString());
            }
            return emails.Values.ToList();
        }
    }

}
