using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainWatch.Collections;
using TrainWatch.Entities;
using TrainWatch.Services;

namespace MyApp.Namespace
{
    public class SearchDatabaseModel : PageModel
    {
        private readonly SearchDatabaseService _service;

        public SearchDatabaseModel(SearchDatabaseService service)
        {
            _service = service ?? throw new ArgumentNullException();
        }

        public PartialList<RollingStock> rollingStocks { get; set; }


        [BindProperty]
        public string PartialName { get; set; }

        public int Current { get; set; }

        public int NextPage
        {
            get
            {
                return Current < LastPage ? Current + 1 : LastPage;
            }
        }

        public int FirstPage { get; set; } = 1;

        public int lastDigit
        {
            get
            {
                return LastPage % PageSize;
            }
        }
        public int LastPage
        {
            get
            {
                if (TotalResults % PageSize != 0)
                {
                    return (TotalResults / PageSize) + 1;
                }
                else
                {
                    return TotalResults / PageSize;
                }
            }
        }

        [BindProperty]
        public int PageSize { get; set; }

        //[BindProperty]
        //public string aspPageSize { get; set; }

        public int PreviousPage
        {
            get
            {
                return Current > 1 ? Current - 1 : 1;
            }
        }

        public int LastPageLink
        {
            get
            {
                int last = (Current + PageSize) - 1;

                if (LastPage < PageSize || (Current <= LastPage && Current >= (LastPage - (lastDigit + 1))))
                {
                    return LastPage;
                }
                else 
                {
                    return last;
                }                 

            }
        }

        public int PageIndex
        {
            get
            {
                return Current - 1;
            }
        }

        public int FromItem
        {
            get
            {
                int offset = PageIndex * PageSize;

                return offset + 1;
            }
        }

        public int ToItem
        {
            get
            {
                if (Current == LastPage)
                {
                    return TotalResults;
                }
                else
                { 

                    return FromItem + PageSize - 1;
                }
            }
        }

        public int TotalResults
        {
            get
            {
                    return rollingStocks.TotalCount;
            }
        }

        public void OnGet(int? currentPage, string partialName, int pageSize)
        {

            if (pageSize != 0)
            {
                PageSize = pageSize;
            }

            else if (pageSize == 0)
            {
                PageSize = 10;
            }


            Current = currentPage.HasValue ? currentPage.Value : 1;

            int skip = PageIndex * PageSize;

            PartialName = partialName;
            if (partialName != null)
            {
                rollingStocks = _service.GetProducts(partialName, skip, PageSize);
            }

            else 
            {
                rollingStocks = _service.GetProducts(skip, PageSize);
            }
        }

        public void OnPost()
        {
            if (PageSize == 0)
            {
                PageSize = 10;
            }

            Current = 1;

            if(PartialName != null)
            {
                rollingStocks = _service.GetProducts(PartialName, 0, PageSize);
            }
            else
            {
                rollingStocks = _service.GetProducts(0, PageSize);
            }
        }
    }
}
