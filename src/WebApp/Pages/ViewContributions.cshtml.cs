using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MyApp.Namespace
{
    public class ViewContributionsModel : PageModel
    {
        [BindProperty]
        public FileInfo[] currentFiles { get; set; }

        [BindProperty]
        public string selectedFile { get; set; }

        [BindProperty]
        public string[] data { get; set; }

        private readonly ILogger<ViewContributionsModel> _logger;

        private readonly IWebHostEnvironment _environment;

        public string nullMessage { get; set; }

        public string ContentRootPath
        {
            get { return _environment.ContentRootPath; }
        }

        public ViewContributionsModel(ILogger<ViewContributionsModel> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public void OnGet()
        {
            string uploadsFolder = System.IO.Path.Combine(ContentRootPath, "Contributions");

            if (!System.IO.Directory.Exists(uploadsFolder))
            {
                System.IO.Directory.CreateDirectory(uploadsFolder);
            }

            DirectoryInfo di = new DirectoryInfo(uploadsFolder);

            currentFiles = di.GetFiles("*.csv");
        }

        public void OnPost()
        {
            string uploadsFolder = System.IO.Path.Combine(ContentRootPath, "Contributions");

            DirectoryInfo di = new DirectoryInfo(uploadsFolder);

            currentFiles = di.GetFiles("*.csv");

            if(selectedFile != null)
            {
                string filePath = System.IO.Path.Combine(uploadsFolder, selectedFile);

                data = System.IO.File.ReadAllLines(filePath);
            }
            else
            {
                nullMessage = "You must select a csv file";
            }
        }
    }
}
