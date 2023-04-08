using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;

namespace TechJobsMVCAutograded6.Controllers;

public class SearchController : Controller
{
    // GET: /<controller>/
    public IActionResult Index()
    {
        ViewBag.columns = ListController.ColumnChoices;
        return View();
    }

    // TODO #3 - Create an action method to process a search request and render the updated search views.

    public IActionResult Results(string searchType, string searchTerm)
    {
        // Get the jobs list based on the search criteria
        var jobs = new List<Job>();

        if (string.IsNullOrEmpty(searchTerm) || searchTerm.ToLower() == "all")
        {
            jobs = JobData.FindAll();
        }
        else
        {
            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
        }

        // Pass the jobs list and column choices to the view
        ViewBag.jobs = jobs;
        ViewBag.columns = ListController.ColumnChoices;

        // Return the view
        return View();

    }
}