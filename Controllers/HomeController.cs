using ExpenceTrackerWebApp.Data;
using ExpenceTrackerWebApp.Models;
using ExpenceTrackerWebApp.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTrackerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Summary Summary { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> SummaryView()
        {
            Summary Summary = new Summary();
            Decimal income = 0;
            Decimal expences = 0;
         
            IEnumerable<Income> TotalIncomeList = await _context.Income.ToListAsync();
            
            foreach(var item in TotalIncomeList)
            {
                income += item.Amount;
            }
            IEnumerable<Expence> TotalExpencesList = await _context.Expence.ToListAsync();

            foreach (var item in TotalExpencesList)
            {
                expences += item.Cost;
            }
            Summary.TotalExpences = expences;
            Summary.TotalIncome = income;
            Summary.AvailableMoney = income - expences / 2;

            return View(Summary);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
