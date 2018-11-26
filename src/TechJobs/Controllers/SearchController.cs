using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.searchType = "all";
            return View();
        }
        
        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            if (searchTerm == null && searchType.Equals("all"))
            {
                ViewBag.jobs = JobData.FindAll();
            }
            else if(searchTerm != null && searchType.Equals("all"))
            {
                ViewBag.jobs = JobData.FindByValue(searchTerm);
            }
            else if(searchTerm == null && searchType.Equals("all") == false)
            {
                ViewBag.jobs = new List<int>();
            }
            else
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            ViewBag.searchType = searchType;
            return View("Index");
        }
    }
}
