using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainWatch.Entities;
using TrainWatch.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace MyApp.Namespace
{
    public class ManageRollingStockModel : PageModel
    {
        private readonly ManageRollingStockService _service;

        public ManageRollingStockModel(ManageRollingStockService service)
        {
            _service = service ?? throw new ArgumentNullException();
        }

        [BindProperty]
        public RollingStock rollingStock { get; set; }

        public List<SelectListItem> railCarType { get; set; }

        public string ErrorMessage { get; set; }
      
        public bool redirected { get; set; }

        public void OnGet(string reportingMark)
        {

            if (!string.IsNullOrEmpty(reportingMark))
            {
                rollingStock = _service.FindRollingStockWithReportingMark(reportingMark);
            }

            PopulateDropDown();
        }

        //this is the handler made specially for redirect so the user can continue adding
        public void OnGetRedirected(string reportingMark)
        {
            if (!string.IsNullOrEmpty(reportingMark))
            {
                rollingStock = _service.FindRollingStockWithReportingMark(reportingMark);

                //"redirected" bool variable is set to true so it could be recognized in the cshtml file
                redirected = true;
            }

            PopulateDropDown();
        }

        public IActionResult OnPostAdd()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.AddRailCar(rollingStock);

                    //In order to make the user able to continue adding after the redirect, I added a page handler
                    return RedirectToPage("ManageRollingStock", "Redirected", new { reportingMark = rollingStock.ReportingMark });
                }

                catch (Exception ex)
                {
                    Exception rootCause = ex;

                    while (rootCause.InnerException != null)
                        rootCause = rootCause.InnerException;

                    ErrorMessage = rootCause.Message;
                    PopulateDropDown();

                    //rollingstock is set to null so the user can continue adding 
                    rollingStock = null;

                    return Page();
                }
            }
            
            PopulateDropDown();
            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateRailCar(rollingStock);

                    //In order to make the user able to continue adding after the redirect, I added a page handler
                    return RedirectToPage("ManageRollingStock", "Redirected", new { reportingMark = rollingStock.ReportingMark });
                }

                catch (Exception ex)
                {
                    Exception rootCause = ex;

                    while (rootCause.InnerException != null)
                        rootCause = rootCause.InnerException;

                    ErrorMessage = rootCause.Message;
                    PopulateDropDown();

                    //rollingstock is set to null so the user can continue adding 
                    rollingStock = null;

                    return Page();
                }
            }
           
            PopulateDropDown();
            return Page();
        }


        public IActionResult OnPostDelete()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.DeleteRailCar(rollingStock);

                    //In order to make the user able to continue adding after the redirect, I added a page handler
                    return RedirectToPage("ManageRollingStock", "Redirected", new { reportingMark = rollingStock.ReportingMark });
                }

                catch (Exception ex)
                {
                    Exception rootCause = ex;

                    while (rootCause.InnerException != null)
                        rootCause = rootCause.InnerException;

                    ErrorMessage = rootCause.Message;
                    PopulateDropDown();

                    //rollingstock is set to null so the user can continue adding 
                    rollingStock = null;

                    return Page();
                }
            }

            PopulateDropDown();
            return Page();
        }


        public void PopulateDropDown()
        {
            railCarType = _service.ListRailCarTypes().Select(x => new SelectListItem(x.Name, x.RailCarTypeID.ToString())).ToList();
        }
    }
}
