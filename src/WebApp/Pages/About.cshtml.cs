using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainWatch.Entities;
using TrainWatch.Services;

namespace MyApp.Namespace
{
    public class AboutModel : PageModel
    {
        private readonly AboutServices _service;
        public DbVersion dbVersion;

        public AboutModel(AboutServices service)
        {
            _service = service;
        }
        public void OnGet()
        {
            dbVersion = _service.GetDbVersion();
        }
    }
}
