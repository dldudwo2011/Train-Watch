using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace WebApp.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public string UserEmail { get; set; }

        [BindProperty]
        public string SelectedTopic { get; set; }

        [BindProperty]
        public string MessageTitle { get; set; }

        public string FeedbackMessage { get; set; }

        public string ContributionMessage { get; set; }

        [BindProperty]
        public IFormFile UserFile { get; set; }

        private readonly ILogger<ContactModel> _logger;

        private readonly IWebHostEnvironment _environment;

        public string ContentRootPath
        {
            get { return _environment.ContentRootPath; }
        }

        public record DataContribution(string TimeStampName, long Length, string OriginalFileName);

        public ContactModel(ILogger<ContactModel> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(UserEmail) && !string.IsNullOrEmpty(SelectedTopic) && !string.IsNullOrEmpty(MessageTitle))
            {
                FeedbackMessage = $"User email: {UserEmail}, Selected topic: {SelectedTopic}, Message title: {MessageTitle}";
            }

            if (UserFile != null)
            {
                string uploadsFolder = System.IO.Path.Combine(ContentRootPath, "Contributions");
                if (!System.IO.Directory.Exists(uploadsFolder))
                {
                    System.IO.Directory.CreateDirectory(uploadsFolder);
                }

                string timeStampFileName = $"{DateTime.Now.ToFileTimeUtc()}.csv";

                string logFileName = "_contributions.log";

                string filePath = System.IO.Path.Combine(uploadsFolder, timeStampFileName);

                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        UserFile.CopyTo(stream);
                    }

                    DataContribution log = new(timeStampFileName, UserFile.Length, UserFile.FileName);

                    string logText = $"{log.TimeStampName}, {log.Length}, {log.OriginalFileName}";

                    string logFilePath = System.IO.Path.Combine(uploadsFolder, logFileName);

                    if (!System.IO.File.Exists(logFilePath))
                    {
                        using (StreamWriter writer = new(logFilePath))
                        {
                            writer.WriteLine(logText);
                        }
                    }
                    else
                    {
                        using (StreamWriter writer = new(logFilePath, true))
                        {
                            writer.WriteLine(logText);
                        }

                    }

                    ContributionMessage = $"Contribution has been received. File is saved as {timeStampFileName}.";
                }
                else
                {
                    ContributionMessage = "Already have that file.";
                }
            }
        }
    }
}