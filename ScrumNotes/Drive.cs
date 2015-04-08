using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace ScrumNotes
{
    class Drive
    {
        private DriveService service = null;
        public string ScrumNotesFolderName = "Scrum Notes";

        /// <summary>
        /// as part of initialization, log in to Drive
        /// </summary>
        public Drive()
        {
            UserCredential credential;
            string secrets = "{\"installed\":{\"auth_uri\":\"https://accounts.google.com/o/oauth2/auth\",\"client_secret\":\"bb2xGM_pLyhYVzXz5pvSR48G\",\"token_uri\":\"https://accounts.google.com/o/oauth2/token\",\"client_email\":\"\",\"redirect_uris\":[\"urn:ietf:wg:oauth:2.0:oob\",\"oob\"],\"client_x509_cert_url\":\"\",\"client_id\":\"287496067068-d9lokec3qedpuk78egrle4jqnjpjltsj.apps.googleusercontent.com\",\"auth_provider_x509_cert_url\":\"https://www.googleapis.com/oauth2/v1/certs\"}}";
            System.IO.MemoryStream secretStream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(secrets ?? ""));
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(secretStream).Secrets,
                new[] { DriveService.Scope.Drive },
                "user",
                CancellationToken.None,
                new FileDataStore("DriveCommandLineSample")).Result;

            // Create the service.
            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample",
            });

        }

        /// <summary>
        /// Gets existing, or creates new folder on Google Drive
        /// </summary>
        /// <returns>Drive File pointing to the scrum notes folder</returns>
        public File getScrumNotesFolder()
        {
            List<Google.Apis.Drive.v2.Data.File> result = new List<Google.Apis.Drive.v2.Data.File>();
            FilesResource.ListRequest request = service.Files.List();
            request.Q = "mimeType='application/vnd.google-apps.folder'";

            do
            {
                try
                {
                    FileList files = request.Execute();
                    foreach (var f in files.Items)
                    {
                        Console.WriteLine(f.Title);
                        if (f.Title == ScrumNotesFolderName)
                        {
                            Console.WriteLine(f.Title);
                            return f;
                        }
                    }
                    result.AddRange(files.Items);
                    request.PageToken = files.NextPageToken;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    request.PageToken = null;
                }
            } while (!String.IsNullOrEmpty(request.PageToken));

            return createScrumNotesFolder();

        }


        /// <summary>
        /// Creates a scrum notes folder
        /// 
        /// </summary>
        /// <returns>Drive File pointing to the scrum notes folder</returns>
 
        public File createScrumNotesFolder() {
            Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File();
            body.Title = "Scrum Notes for Today";
            body.Description = "Scrum Notes for Today";
            body.MimeType = "application/vnd.google-apps.folder";

            FilesResource.InsertRequest insReq = service.Files.Insert(body);
            return insReq.Execute();
        }

        public void saveNotes(string noteText){

            File parentFolder = getScrumNotesFolder();
            getScrumNotesFolder();

            Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File();
            body.Title = "Scrum Notes";
            body.Description = "Scrum Notes";
            body.MimeType = "text/plain";
            body.Parents = new List<ParentReference>() { new ParentReference() {Id = parentFolder.Id }};

            System.IO.MemoryStream stream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(noteText ?? ""));

            FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "text/plain");

            request.Upload();


            /*
             * Google.Apis.Drive.v2.Data.File file = request.ResponseBody;
            Console.WriteLine("File id: " + file.Id);
            Console.WriteLine("Press Enter to end this process.");
            Console.ReadLine();
             * */
        }

    }
}
