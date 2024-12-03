using Microsoft.AspNetCore.Mvc;
using Passport2.Models;
using System;
using System.Collections.Generic;

namespace Passport2.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<UserDetails> _users = new()
        {
            new UserDetails { Id = 1, FullName = "John Doe", Email = "john@example.com", PhoneNumber = "123456789", Country = "Jordan" },
            new UserDetails { Id = 2, FullName = "Jane Smith", Email = "jane@example.com", PhoneNumber = "987654321", Country = "Jordan" }
        };

        private static readonly List<PassportApplication> _applications = new()
        {
            new PassportApplication { ApplicationID = 1, UserDetailsId = 1, Status = "Approved", DateOfApplication = DateTime.Now.AddDays(-10) },
            new PassportApplication { ApplicationID = 2, UserDetailsId = 2, Status = "Pending", DateOfApplication = DateTime.Now.AddDays(-5) }
        };

        private static readonly List<ResidencyApplication> _residencyApplications = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserDetails()
        {
            return View(_users);
        }

        public IActionResult PassportRenewal()
        {
            return View(); // This will load the Passport Renewal view
        }

        public IActionResult PassportApplication()
        {
            return View(); // This will load the Passport Application view
        }

        public IActionResult PassportRequiredDocuments()
        {
            return View(); // This will load the Required Documents view for Passport Renewal
        }

        public IActionResult ResidencyForForeigners()
        {
            return View(); // This will load the Residency For Foreigners view
        }

        public IActionResult RequiredDocuments()
        {
            return View(); // This will load the Required Documents view for Residency Application
        }

        public IActionResult ResidencyApplication()
        {
            return View("ResidencyApplication"); // This will load the Residency Application view
        }

        [HttpPost]
        public IActionResult PassportApplication(PassportApplication model)
        {
            if (ModelState.IsValid)
            {
                _applications.Add(model); // Simulating saving to a database
                return RedirectToAction("Success");
            }

            return View("PassportApplication", model);
        }

        // POST method for Passport Renewal
        [HttpPost]
        public IActionResult PassportAppliccation(PassportApplication model)
        {
            if (ModelState.IsValid)
            {
                model.DateOfApplication = DateTime.Now;
                _applications.Add(model); // Simulating saving to a database
                return RedirectToAction("Success");
            }

            return View("PassportAppliccation", model);
        }

        // POST method for Residency Application
        [HttpPost]
        public IActionResult ResidencyApplication(ResidencyApplication model)
        {
            if (ModelState.IsValid)
            {
                _residencyApplications.Add(model); // Simulating saving to a database
                return RedirectToAction("Success");
            }

            return View("ResidencyApplication", model);
        }

        // Success page after application submission
        public IActionResult Success()
        {
            return View();
        }
    }
}
