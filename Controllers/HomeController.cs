using Microsoft.AspNetCore.Mvc;
using Passport2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Passport2.Controllers
{
    public class HomeController : Controller
    {
        // Mock data for users and applications
        private static readonly List<UserDetails> _users = new()
        {
            new UserDetails { Id = 1, FullName = "John Doe", Email = "john@example.com", PhoneNumber = "123456789", Country = "Jordan" },
            new UserDetails { Id = 2, FullName = "Jane Smith", Email = "jane@example.com", PhoneNumber = "987654321", Country = "Jordan" }
        };

        private static readonly List<PassportApplication> _passportApplications = new()
        {
            new PassportApplication { ApplicationID = 1, UserDetailsId = 1, Status = "Approved", DateOfApplication = DateTime.Now.AddDays(-10) },
            new PassportApplication { ApplicationID = 2, UserDetailsId = 2, Status = "Pending", DateOfApplication = DateTime.Now.AddDays(-5) }
        };

        private static readonly List<ResidencyApplication> _residencyApplications = new()
        {
            new ResidencyApplication { ResidencyApplicationID = 1, FullName = "Alice Brown", PassportNumber = "RB12345", Email = "alice@example.com", Status = "Approved", DateOfApplication = DateTime.Now.AddDays(-8) },
            new ResidencyApplication { ResidencyApplicationID = 2, FullName = "Bob White", PassportNumber = "RW67890", Email = "bob@example.com", Status = "Pending", DateOfApplication = DateTime.Now.AddDays(-3) }
        };

        private static readonly List<string> _documentsNeeded = new()
        {
            "Passport Renewal: Valid passport, proof of address, application form",
            "Residency: Passport, proof of employment, residency application form"
        };

        private static readonly Dictionary<string, string> _fees = new()
        {
            { "Passport Renewal", "$100" },
            { "Residency Application", "$150" }
        };

        // Action to load the home page
        public IActionResult Index()
        {
            return View();
        }

        // Additional actions (unchanged)
        public IActionResult CreatePassportApplication()
        {
            return View(new PassportApplication());
        }

        public IActionResult CreateResidencyApplication()
        {
            return View(new ResidencyApplication());
        }

        public IActionResult PassportRenewal()
        {
            return View();
        }

        public IActionResult PassportRequiredDocuments()
        {
            return View();
        }

        public IActionResult RequiredDocuments()
        {
            return View();
        }

        public IActionResult ResidencyForForeigners()
        {
            return View();
        }

        public IActionResult UserDetails()
        {
            return View(_users);
        }
        public IActionResult Fees()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePassportApplication(PassportApplication model)
        {
            if (ModelState.IsValid)
            {
                model.ApplicationID = _passportApplications.Count + 1;
                model.DateOfApplication = DateTime.Now;
                model.Status = "Pending";
                _passportApplications.Add(model);

                return RedirectToAction("Success");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateResidencyApplication(ResidencyApplication model)
        {
            if (ModelState.IsValid)
            {
                model.ResidencyApplicationID = _residencyApplications.Count + 1;
                model.DateOfApplication = DateTime.Now;
                model.Status = "Pending";
                _residencyApplications.Add(model);

                return RedirectToAction("Success");
            }

            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult ThankYou()
        {
            return View();
        }
        // Search feature
        [HttpPost]
        public IActionResult Search(string query)
        {
            // Filter passport applications based on query (name or status)
            var passportResults = _passportApplications
                .Where(p => p.Status.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Filter residency applications based on query (name or passport number)
            var residencyResults = _residencyApplications
                .Where(r => r.FullName.Contains(query, StringComparison.OrdinalIgnoreCase) || r.PassportNumber.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Create a view model or use a Tuple to send both results
            var results = new Tuple<List<ResidencyApplication>, List<PassportApplication>>(residencyResults, passportResults);

            // Return to the Search view with results
            return View("Search", results);
        }
    }
}
